using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Configuration;
using System.Diagnostics;
using System.Web;
using SDS.SDSRequest.Factory;
using SDS.SDSRequest.Models;
using PG.Gps.DepotClient.Model;
using PG.Gps.DepotClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using SDS.SDSRequest.Common;
using AutoMapper;

namespace SDS.SDSRequest.Controllers
{
    
    public class PassFormulaController
    {
        // GET: PassFormula

        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        private static DepotAccessRecord depotAccessRecord = new DepotAccessRecord();
        private static string UpdatedBy = HttpContext.Current.User.Identity.Name.ToString();
        private static string url = HttpContext.Current.Request.Url.ToString();
        private static string SourceSystem = ConfigurationManager.AppSettings["SourceSystem"];

        private static IEnumerable<string> GetFormulaComponentList(List<DepotCompositionPart> calculatedComponents)
        {
            //IEnumerable<string> partKeys = null;
            var partKeys = new List<string>();
            if (calculatedComponents.Count() == 0)
            {
                return partKeys;
            }
            //partKeys = new string[] { };
            //partKeys = Enumerable.Empty<string>();
            foreach (DepotCompositionPart comp in calculatedComponents)
                partKeys.Add(comp.ChildPart?.PartKey); //comp.PartKey >> comp.ChildPart?.PartKey
                //partKeys.ToList().Add(comp.PartKey);
            return partKeys;
        }

		public static List<Part> GetBestParts(string srcKeys)
		{
			string[] keys = srcKeys.Split(',').Distinct().ToArray().Where(x => !string.IsNullOrEmpty(x)).ToArray(); //remove duplicate and empty array elements

			List<string> revKeys = new List<string>();

			string depotUser = depotAccessRecord.DepotUser;
			string depotPwd = depotAccessRecord.DepotPass;

			var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{depotUser}:{depotPwd}"));
			var depotAuth = new AuthenticationHeaderValue("Basic", credentials);

			using (HttpClient client = new HttpClient())
			{
				client.DefaultRequestHeaders.Authorization = depotAuth;
				var c = new GpsDepotClient(depotAccessRecord.DepotUrl, client);

				Logger.Trace("Calling Parts.GetParts to get best parts only {0}", srcKeys);

				List<Part> partResults = c.GetPartsAsync(new PartControllerGetPartsRequest()
				{
					BestPartsOnly = true,
					SrcKeys = keys,
				}).GetAwaiter().GetResult().ToList<Part>();
				return partResults;
			}
		}

		public static List<DepotOperationResultStatus> GetPartTypes(string prodKeys, string sourceSystem)
        {
            Dictionary<string, string> productTypes = new Dictionary<string, string>();
            List<DepotOperationResultStatus> request_ret = new List<DepotOperationResultStatus>();
            DepotOperationResultStatus part_ret;
            string[] lookupKeys;

            string prodKeysCommaDelimited = Regex.Replace(prodKeys, @"\r\n?|\n", ",");
            string partType = "";
            lookupKeys = prodKeysCommaDelimited.Replace(" ", "").Split(','); //allow only one or no spaces between commas
			IMapper mapper = MapUtil.Mapper;
			string depotUser = depotAccessRecord.DepotUser;
			string depotPwd = depotAccessRecord.DepotPass;

			var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{depotUser}:{depotPwd}"));
			var depotAuth = new AuthenticationHeaderValue("Basic", credentials);

			using (HttpClient client = new HttpClient())
			{
				var depot = new GpsDepotClient(depotAccessRecord.DepotUrl, client);
				string errorMsg = "";
				Dictionary<string, DepotPart> bestparts = (mapper.Map<List<Part>, List<DepotPart>>(depot.GetPartsAsync(new PartControllerGetPartsRequest()
															{
																BestPartsOnly = true,
																SrcKeys = lookupKeys,
															}).GetAwaiter().GetResult().ToList<Part>())
															?? new List<DepotPart>(0)).ToDictionary(p => p.PartSrcKey, p => p, StringComparer.OrdinalIgnoreCase);

				foreach (KeyValuePair<string, DepotPart> thispart in bestparts)
                {
                    part_ret = new DepotOperationResultStatus();
                    partType = thispart.Value.PartTypeCode;
                    part_ret.PartTypeName = partType;
                    part_ret.RequestedPart = thispart.Value.PartSrcKey;
                    //if (partType.Equals("RMP") || partType.Equals("RMP"))
                    //productTypes.Add(thispart.Value.PartKey, thispart.Value.PartTypeName + "[" + thispart.Value.PartTypeCode + "]");
                    request_ret.Add(part_ret);

                    /*
                    string PartTypeCode = thispart.Value.PartTypeCode;
                    string PartPrimaryOrganizationName = thispart.Value.PartPrimaryOrganizationName;
                    string PartGbuName = thispart.Value.PartGbuName;
                    string PartPlmTypeName = thispart.Value.PartPlmTypeName;
                    string PartPlmStateName = thispart.Value.PartPlmStateName;
                    string PartStatusName = thispart.Value.PartStatusName;
                    */
                }
            }
            return request_ret;
        }

        private static string GetCurrentUser()
        {
            string url = HttpContext.Current.Request.Url.ToString();
            string curuser = null;

            if (url.Contains("localhost"))
                curuser = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            else
                curuser = HttpContext.Current.User.Identity.Name.ToString();

            return curuser.Substring(curuser.IndexOf('\\')+1);
        }

        public static void StartDTE()
        {
            DbEfFactory.StartDTE();

        }

        /*
        public static DepotOperationResultStatus ProcessDepotBOMRequest(string targetFormulaKey, int rmFormulaLowerLimitValidation, int rmFormulaUpperLimitValidation, List<BOMIngredient> bomIngredients, int? existingRequestId = 0)
        {
            //assumptions: all formulations are in WERCS, so we don't need to go to Depot for anything here.
            //if a formula for a material in the BOM isn't in WERCS, it should be imported into WERCS before starting the BOM formula request
            UpdatedBy = GetCurrentUser();

            //List<DepotOperationResultStatus> request_ret = new List<DepotOperationResultStatus>();
            //DepotOperationResultStatus r;
            //string[] lookupKeys = new string[bomIngredients.Count() - 1];

            //loop in get_bos_depot and see if there's errors

            DepotOperationResultStatus bos_ret = DbEfFactory.AddDepotBOMRequest(targetFormulaKey, bomIngredients, rmFormulaLowerLimitValidation, rmFormulaUpperLimitValidation, "BOM Request", UpdatedBy, null);

            List<BOMIngredient> depotParts = bomIngredients.Where(p => p.RMSource.ToLower().Contains("depot")).ToList<BOMIngredient>();
            //List<BOMIngredient> wercsParts = bomIngredients.Where(p => p.RMSource.ToLower().Contains("wercs")).ToList<BOMIngredient>();
            if (depotParts?.Any() ?? false)
            {
                string prodKeys = string.Join(",", depotParts.Select(a => a.RMKey.ToString()));
                List<DepotOperationResultStatus> get_bos_depot = ProcessDepotRequest(prodKeys, sourceSystem: "Depot", overrideBOSErrors: true, formulaLowerPercentValidation:0, formulaUpperPercentValidation:0, existingRequestId:bos_ret.RequestId);
            }

            //DepotOperationResultStatus ret = new DepotOperationResultStatus();
            if (bos_ret.RequestId > 0 && string.IsNullOrEmpty(bos_ret.ErrorMessage))
                bos_ret = DbEfFactory.ProcessBOMRequest(bos_ret.RequestId, targetFormulaKey, "Depot");

            return bos_ret;

        }
        */

        public static List<DepotOperationResultStatus> TEST_ProcessDepotGetCalculatedBosRequest(string prodKeys, string sourceSystem, bool overrideBOSErrors, int formulaLowerPercentValidation, int formulaUpperPercentValidation, int? existingRequestId = 0)
        {
            UpdatedBy = GetCurrentUser();

            //existingRequestId: is this a brand new request (existingRequestId = 0) or a request that was partially processed before 
            List<DepotOperationResultStatus> request_ret = new List<DepotOperationResultStatus>();
            DepotOperationResultStatus r;
            string[] lookupKeys;
            string prodKeysCommaDelimited = Regex.Replace(prodKeys, @"\r\n?|\n", ",");
            if (existingRequestId == 0)
            {
                lookupKeys = prodKeysCommaDelimited.Replace(" ", "").Split(','); //allow only one or no spaces between commas
            }
            else
                lookupKeys = DbEfFactory.GetUnprocessedRequestParts(existingRequestId.GetValueOrDefault()); //allow only one or no spaces between commas

			IMapper mapper = MapUtil.Mapper;
			string depotUser = depotAccessRecord.DepotUser;
			string depotPwd = depotAccessRecord.DepotPass;

			var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{depotUser}:{depotPwd}"));
			var depotAuth = new AuthenticationHeaderValue("Basic", credentials);

			using (HttpClient client = new HttpClient())
			{
				var depot = new GpsDepotClient(depotAccessRecord.DepotUrl, client);
				string errorMsg = "";
				Dictionary<string, DepotPart> bestparts = (mapper.Map<List<Part>, List<DepotPart>>(depot.GetPartsAsync(new PartControllerGetPartsRequest()
															{
																BestPartsOnly = true,
																SrcKeys = lookupKeys,
															}).GetAwaiter().GetResult().ToList<Part>())
															?? new List<DepotPart>(0)).ToDictionary(p => p.PartSrcKey, p => p, StringComparer.OrdinalIgnoreCase);


				DepotOperationResultStatus bos_ret = DbEfFactory.AddDepotFormulaRequest(prodKeysCommaDelimited, formulaLowerPercentValidation, formulaUpperPercentValidation, bestparts, "Depot", "Formula Request", UpdatedBy);

                ICalculatedComponentsResult result;
                foreach (KeyValuePair<string, DepotPart> thispart in bestparts)
                {
                    //ICalculatedComponentsResult result = depot.BillOfSubstance.GetCalculatedComponentsForBestPart(sourcekey, forSds: true, requireSDSSpecific: false, includeFragranceComposition: true);
                    //thispart.PartKey = "91119915.004";
                    //ICalculatedComponentsResult result = depot.BillOfSubstance.GetCalculatedComponentsForPart(thispart.Value, forSds: true, includeFragranceComposition: true, requireSDSSpecific: false);
                    result=depot.GetCalculatedComponentsForPartAsync(part: thispart.Value,
                                                                    forSds: true,
                                                                    includeFragranceComposition: true,
																	includeGpsConfidentialComposition: false
                                                                        ).GetAwaiter().GetResult();

                    bos_ret.ResultCount = result.CalculatedComponents?.Count() ?? 0;
                    //more processing it... just testing various methods of the depot.BillOfSubstance
                }
            }
            return request_ret;
        }

        public static async Task<List<DepotOperationResultStatus>> ProcessDepotRequest(string prodKeys, string sourceSystem, bool overrideBOSErrors, int formulaLowerPercentValidation, int formulaUpperPercentValidation, int? existingRequestId = 0, int? parentBOMRequestId=0, string BOMRequestTargetKey=null)
        //public static List<DepotOperationResultStatus> ProcessDepotRequest(string prodKeys, string sourceSystem, int formulaLowerPercentValidation, int formulaUpperPercentValidation, int? existingRequestId = 0)
        {
            UpdatedBy = GetCurrentUser();

            //existingRequestId: is this a brand new request (existingRequestId = 0) or a request that was partially processed before 
            List<DepotOperationResultStatus> request_ret = new List<DepotOperationResultStatus>();
            DepotOperationResultStatus r;
            string[] lookupKeys;
            string prodKeysCommaDelimited = Regex.Replace(prodKeys, @"\r\n?|\n", ",");
            if (existingRequestId == 0)
            {
                lookupKeys = prodKeysCommaDelimited.Replace(" ", "").Split(','); //allow only one or no spaces between commas
            }
            else
            {
                lookupKeys = DbEfFactory.GetUnprocessedRequestParts(existingRequestId.GetValueOrDefault()); //allow only one or no spaces between commas
            }
            //Dictionary<string, DepotPart> results;



            DepotOperationResultStatus bos_ret = new DepotOperationResultStatus();
			IMapper mapper = MapUtil.Mapper;
			string depotUser = depotAccessRecord.DepotUser;
			string depotPwd = depotAccessRecord.DepotPass;

			var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{depotUser}:{depotPwd}"));
			var depotAuth = new AuthenticationHeaderValue("Basic", credentials);


			List<Part> bestpartsList = GetBestParts(prodKeysCommaDelimited);

			using (HttpClient client = new HttpClient())
			{
				client.DefaultRequestHeaders.Authorization = depotAuth;
				var depot = new GpsDepotClient(depotAccessRecord.DepotUrl, client);
				string errorMsg = "";
				List<DepotPart> depotPartsList = mapper.Map<List<Part>, List<DepotPart>>(bestpartsList);
				Dictionary<string, DepotPart> bestparts = depotPartsList.ToDictionary(p => p.PartSrcKey, p => p, StringComparer.OrdinalIgnoreCase);
              //  Dictionary<string, DepotPart> bestparts = (mapper.Map<List<Part>, List<DepotPart>>().GetAwaiter().GetResult().ToList<Part>())
														//?? new List<DepotPart>(0)).ToDictionary(p => p.PartSrcKey, p => p, StringComparer.OrdinalIgnoreCase);

                if (bestparts.Count == 0)
                {
                    //bos_ret.RequestedPart = sourcekey;
                    if (parentBOMRequestId > 0)
                    {
                        bos_ret.ResultCount = 0;
                        bos_ret.RequestId = parentBOMRequestId.GetValueOrDefault();
                        //bos_ret.ProcessedPartKey=
                        bos_ret.ErrorMessage = "Error encountered, no bestparts found for "+ prodKeysCommaDelimited +" in BOM Request# "+ parentBOMRequestId.GetValueOrDefault().ToString() + " or service may not be available.";
                        bos_ret.ErrorReceived = true;
                        DbEfFactory.UpdateBOSLoadStatus("bom_load_failed", UpdatedBy, bos_ret);
                    }
                    else
                    {
                        bos_ret.ResultCount = 0;
                        bos_ret.ErrorMessage = "Error encountered, no bestparts found for " + prodKeysCommaDelimited + ", or service may not be available.";
                        DbEfFactory.UpdateBOSLoadStatus("bos_load_failed", UpdatedBy, bos_ret);
                    }
                    request_ret.Add(new DepotOperationResultStatus(bos_ret));
                    return request_ret;
                }

                if (bestparts.Count > 0 && bestparts.Count < lookupKeys.Length)
                {
                    errorMsg = "";
                    foreach (string mykey in lookupKeys)
                    {
                        if (!bestparts.ContainsKey(mykey))
                        {
                            errorMsg += mykey + ",";
                        }
                    }
                    errorMsg = "The following key(s) are missing bestpart: " + errorMsg.TrimEnd(',');
                    bos_ret.ErrorMessage = "Error encountered, " + errorMsg + " in BOM Request# " + parentBOMRequestId.GetValueOrDefault().ToString() + ".";
                    bos_ret.ErrorReceived = true;
                    //bos_ret.ResultCount = 0;
                    bos_ret.RequestId = parentBOMRequestId.GetValueOrDefault();
                    request_ret.Add(new DepotOperationResultStatus(bos_ret));


                    DbEfFactory.UpdateBOSLoadStatus("bom_load_failed", UpdatedBy, bos_ret);

                    //return request_ret;
                }
                if (parentBOMRequestId == 0)
                    bos_ret = DbEfFactory.AddDepotFormulaRequest(prodKeysCommaDelimited, formulaLowerPercentValidation, formulaUpperPercentValidation, bestparts, "Depot", "Formula Request", UpdatedBy);
                else
                {
                    //write PartName, PartType, etc. in the formula_request_queue table...
                    bos_ret = DbEfFactory.UpdateBOMRequestDepotFormula(prodKeysCommaDelimited, formulaLowerPercentValidation, formulaUpperPercentValidation, bestparts, "Depot", parentBOMRequestId.GetValueOrDefault(), BOMRequestTargetKey, UpdatedBy);
                    bos_ret.RequestId = parentBOMRequestId.GetValueOrDefault();
                    bos_ret.StatusCode = "0";
                }
                foreach (KeyValuePair<string, DepotPart> thispart in bestparts)
                {
                    //ICalculatedComponentsResult result = depot.BillOfSubstance.GetCalculatedComponentsForBestPart(sourcekey, forSds: true, requireSDSSpecific: false, includeFragranceComposition: true);
                    //thispart.PartKey = "91119915.004";
                    //ICalculatedComponentsResult result = depot.BillOfSubstance.GetCalculatedComponentsForPart(thispart.Value, forSds: true, includeFragranceComposition: true, requireSDSSpecific: false);
                    ICalculatedComponentsResult result = await depot.GetCalculatedComponentsForPartAsync(thispart.Value,
																				forSds: true,
																				includeFragranceComposition: true,
																				requireSDSSpecific: false,
																				partTypesForAssessmentSpecs: null,
																				allowResultWhenBosErrors: overrideBOSErrors);
                    //use mypartTypesForAssessmentSpecs to override default values

                    bos_ret.ResultCount = result.CalculatedComponents?.Count() ?? 0;

                    if (bos_ret.ResultCount == 0)
                    {
                        //bos_ret.RequestedPart = sourcekey;
                        bos_ret.RequestedPart = thispart.Key;
                        bos_ret.ProcessedPartKey = "";
                        //bos_ret.ErrorMessage = "No Parts Found for " + sourcekey;
                        bos_ret.ErrorMessage = "No Parts Found for " + thispart.Key +" in BOM Request# " + parentBOMRequestId.GetValueOrDefault().ToString() + ".";
                        bos_ret.ErrorReceived = true;
                        bos_ret.ResultCount = 0;
                        //request_ret.Add(new DepotOperationResultStatus(bos_ret));
                        DbEfFactory.UpdateBOSLoadStatus("bos_load_missing", UpdatedBy, bos_ret);
                        if ((result.Errors?.Any() ?? false) || (result.Warnings?.Any() ?? false))
                            r = DbEfFactory.SaveDepotRequestBos(bos_ret.RequestId, bos_ret.RequestedPart, sourceSystem, UpdatedBy, result, null);

                        request_ret.Add(new DepotOperationResultStatus(bos_ret));
                        continue; //fetch the next sourcekey in lookupKeys
                    }

                    else
                    {
                        try
                        {
                            DepotPart part = result?.SourceParts?.FirstOrDefault();
                            bos_ret.RequestedPart = part.PartSrcKey;
                            bos_ret.ProcessedPartKey = part.PartKey; //part.PartSrcKey+"."+part.PartSrcRevision;
                            bos_ret.PartTypeName = part.PartTypeName;
                            DbEfFactory.UpdateBOSLoadStatus("bos_load_started", UpdatedBy, bos_ret);
                            /*
                            IEnumerable<string> attrNameFilter = new[]{"PRIMARY CAS #","Primary CAS Region", "CAS #"};
                            //IEnumerable<string> partKeys = new[] { part.PartKey };

                            IEnumerable<string> partKeys = GetFormulaComponentList(result.CalculatedComponents);
                            List<DepotPartAttribute> partMultiCASAttributes=null;
                            if ((partKeys?.Count() ?? 0) >0)
                                partMultiCASAttributes = depot.Parts.GetPartAttributesByPartKeys(partKeys, attrNameFilter);
                            */

                            r = DbEfFactory.SaveDepotRequestBos(bos_ret.RequestId, bos_ret.RequestedPart, sourceSystem, UpdatedBy, result, partMultiCASAttributes: null);
                            bos_ret.ResultCount = result.CalculatedComponents?.Count() ?? -1; // bos?.Count() ?? -1;
                            if (bos_ret.ResultCount == -1)
                                DbEfFactory.UpdateBOSLoadStatus("bos_load_completed_with_errors", UpdatedBy, bos_ret);
                            else
                                DbEfFactory.UpdateBOSLoadStatus("bos_load_completed", UpdatedBy, bos_ret);
                            bos_ret.SuccessMessage = r.SuccessMessage;
                            bos_ret.ErrorMessage = r.ErrorMessage;
                            //bos_ret.RequestedPart = bos_ret.RequestedPart; //part.PartSrcKey;
                            //bos_ret.ProcessedPartKey = bos_ret.ProcessedPartKey; //part.PartKey; //part.PartSrcKey+"."+part.PartSrcRevision;
                            //request_ret.Add(bos_ret);
                        } //try


                        catch (Exception e)
                        {
                            bos_ret.SuccessMessage = null;
                            bos_ret.ErrorMessage = "Message:" + e.Message + ". "; // InnerException:" + e.InnerException.Message;
                            Logger.Error(e, "Error Processing Depot Rquest");
                            //request_ret.Add(bos_ret);
                            DbEfFactory.UpdateBOSLoadStatus("bos_load_failed", UpdatedBy, bos_ret);
                            request_ret.Add(new DepotOperationResultStatus(bos_ret));
                            continue;
                        }
                    } //else

                    //request_ret.Add(bos_ret);
                    request_ret.Add(new DepotOperationResultStatus(bos_ret));


                } //foreach
            } //using
            return request_ret;

        }


    }
}

