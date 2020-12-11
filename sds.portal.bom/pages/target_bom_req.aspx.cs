using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PG.Gps.DepotClient.Model;
using System.Configuration;
using System.Diagnostics;
using System.Text.RegularExpressions;
using SDS.SDSRequest.Models;
using SDS.SDSRequest.Controllers;


namespace SDS.Portal.Web.pages
{
    public partial class create_target_bom_req : System.Web.UI.Page
    {
        void DisplayRequestResult(List<DepotOperationResultStatus> result)
        {
            PassResultDisplayDiv.InnerHtml = "";
            string processedPartKey = "", successMessage = "";
            foreach (DepotOperationResultStatus r in result)
            {
                processedPartKey = string.IsNullOrEmpty(r.ProcessedPartKey) ? "PartKey Not Processed" : r.ProcessedPartKey;
                successMessage = string.IsNullOrEmpty(r.SuccessMessage) ? "Blank Success Message" : r.SuccessMessage;

                PassResultDisplayDiv.InnerHtml += " >" + r.RequestId + " - " + r.RequestedPart + " - " + processedPartKey + " - ResultCount=" + r.ResultCount + " - " + successMessage + " - " + r.ErrorMessage;
            }
        }
        void MonitorBOMRequestProcess(int RequestId, string targetFormulaKey)
        {
            Response.Redirect("target_bom_result.aspx?RequestId="+ RequestId.ToString()+ "&targetFormulaKey="+ targetFormulaKey, false);
        }

        private async void ProcessBOMRequest(string bom_sourceSystem, string targetFormulaKey, int rmFormulaLowerLimitValidation, int rmFormulaUpperLimitValidation, List<BOMIngredient> bomIngredients)
        {
            List<DepotOperationResultStatus> bos_ret;
            System.Web.HttpContext httpContext = System.Web.HttpContext.Current;
            BOMRequestController bomrc = new BOMRequestController(httpContext);

            bos_ret = await bomrc.ProcessDepotBOMRequest(targetFormulaKey, rmFormulaLowerLimitValidation, rmFormulaUpperLimitValidation, bomIngredients);
            bool bom_process_success = true;
            string errorMsg = "";
            foreach (DepotOperationResultStatus ret in bos_ret)
            {
                if (!string.IsNullOrEmpty(ret.ErrorMessage))
                {
                    errorMsg += ret.ErrorMessage + ",";
                    //PassResultDisplayDiv.InnerHtml += "<span style='color:#000000'>" + " " + ret.ErrorMessage + "</span>";
                    bom_process_success = false;
                }
            }

            //don't check depotLoadSuccess here... Request will be processed regardless and all errors (depot and wercs) will be on the status (result) page
            /*
            if (bom_process_success)
            {
                //MonitorBOMRequestProcess(ret.RequestId, targetFormulaKey);
                MonitorBOMRequestProcess(bos_ret.FirstOrDefault().RequestId, targetFormulaKey);
                PassResultDisplayDiv.InnerHtml = "<span style='color:#000000'>" + "Request queued and will be processed " + "</span>";

            }
            else
                PassResultDisplayDiv.InnerHtml = "<span style='color:#000000'>" + "  " + errorMsg.TrimEnd(',') + "</span>";
            */
            MonitorBOMRequestProcess(bos_ret.FirstOrDefault().RequestId, targetFormulaKey);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            PassResultDisplayDiv.InnerHtml = "";
        }

        private string getKeySource(string SrcKey)
        {
            //int gcascode;
            //bool isnumericGcas = int.TryParse(SrcKey.Substring(1, 8), out gcascode);
            bool isInWercs = SrcKey.Contains("SDSOWND");
            
            if (isInWercs)
                return "Wercs";
            else return "Depot";
        }
        private List<BOMIngredient> getBOMIngredients(bool overrideFormulaSource, List<string> rmList)
        {
            List<BOMIngredient> bomIngredients = new List<BOMIngredient>();
            if (overrideFormulaSource) //if source system is provided in the input on the format, GCAS, percent, source system; etc. This was an initial design idea but may have to be completely taken out
            {
                foreach (string rm_item in rmList)
                {
                    // This might be fun if you get two of the same object in the collection.
                    // Since this key is based off of the results of the GetHashCode() object in the base object class.
                    BOMIngredient rm = new BOMIngredient();
                    string[] rmArr = rm_item.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    if (rmArr.Length != 3)
                    {
                        throw new System.ArgumentException("Incorrect Raw Material Properties align", "Incorrect RM Input Format");
                    }
                    rm.RMKey = rmArr[0];        //rm_item.Substring(0, rm_item.IndexOf(','));
                    rm.RMPercent = Convert.ToDecimal(rmArr[1]);    //Convert.ToDecimal(rm_item.Substring(rm_item.IndexOf(',') + 1, rm_item.IndexOf('%') - (rm_item.IndexOf(',') + 1)));
                    rm.RMSource = rmArr[2];
                    bomIngredients.Add(rm);
                }
            }
            else  //if source system is not provided in the input, default to "WERCS", meaning RM have already been imported to WERCS
            {
                foreach (string rm_item in rmList)
                {
                    // This might be fun if you get two of the same object in the collection.
                    // Since this key is based off of the results of the GetHashCode() object in the base object class.
                    BOMIngredient rm = new BOMIngredient();
                    string[] rmArr = rm_item.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    if (rmArr.Length != 2)
                    {
                        throw new System.ArgumentException("Incorrect Raw Material Properties align", "Incorrect RM Input Format");
                    }
                    rm.RMKey = rmArr[0];        //rm_item.Substring(0, rm_item.IndexOf(','));
                    rm.RMPercent = Convert.ToDecimal(rmArr[1]);    //Convert.ToDecimal(rm_item.Substring(rm_item.IndexOf(',') + 1, rm_item.IndexOf('%') - (rm_item.IndexOf(',') + 1)));
                    //rm.RMSource = "WERCS";
                    rm.RMSource = getKeySource(rm.RMKey); //Depot or WERCS based on...
                    bomIngredients.Add(rm);
                }
            }
            return bomIngredients;
        }

        protected void cmdStageBOM_Click(object sender, EventArgs e)
        {

            string BOMSourceSystem = ConfigurationManager.AppSettings["BOMSourceSystem"];
            string BOM100PercentInputValidation = ConfigurationManager.AppSettings["BOM100PercentInputValidation"];
            bool BomPercentValidation = false;
            bool.TryParse(BOM100PercentInputValidation, out BomPercentValidation);

            string TargetFormulaKey = txtTargetBOM.Value;
            string RMKeys = txtRMList.Value;
            RMKeys = Regex.Replace(RMKeys, @"\r\n?|\n", ";"); //replace CR with semi-colon
            //RMKeys = Regex.Replace(RMKeys, @"\s+", ""); //remove all spaces --> don't remove spaces per Lee on 11/24/2020
            RMKeys = Regex.Replace(RMKeys, @"%", ""); //remove percent signs. This will keep the percent as a numeric value, simplifying validation

            try
            {
                if (string.IsNullOrEmpty(TargetFormulaKey) || string.IsNullOrEmpty(RMKeys))
                {
                    throw new System.ArgumentException("Missing Target Formula Key or Raw Materials", "Missing Target");
                }

                //prevents a single item list with an empty item if the rmList string is empty
                //IEnumerable<string> rmList = !string.IsNullOrEmpty(RMKeys) ? RMKeys.Split(';') : Enumerable.Empty<string>();
                List<string> rmList = RMKeys.Split(';').ToList() ;

                rmList.RemoveAll(p => p == "");

                bool overrideFormulaSource = false;
                //overrideFormulaSource is a flag that indicates whether the formula source system is included in the input. 
                //Old design assumption was that we were getting these formulas imported from their source system as part of this process.
                //Then, it was decided that these RM will always be in WERCS first. This functionality can, however, be restored if needed.

                List<BOMIngredient> bomIngredients = getBOMIngredients(overrideFormulaSource, rmList);

                if (BomPercentValidation == true)
                {
                    decimal sumpercent = bomIngredients.Sum(item => item.RMPercent);
                    if (sumpercent != 100)
                    {
                        throw new System.ArgumentException("The make up of all Raw Materials must add up to exactly 100", "Incorrect Percentages of RM provided");
                    }
                }
                int lowerLimitValidation = 0, upperLimitValidation = 0;

                string RMLowerLimitValidation = ConfigurationManager.AppSettings["BOMBuildingBlockLowerLimitValidation"];
                string RMUpperLimitValidation = ConfigurationManager.AppSettings["BOMBuildingBlockUpperLimitValidation"];

                if (Int32.TryParse(RMLowerLimitValidation, out lowerLimitValidation) && Int32.TryParse(RMUpperLimitValidation, out upperLimitValidation))
                {
                    ProcessBOMRequest(BOMSourceSystem, TargetFormulaKey, lowerLimitValidation, upperLimitValidation, bomIngredients);

                }


            }
            catch (Exception ex)
            {
                PassResultDisplayDiv.InnerHtml = "<span style='color:#FF0000'>"+ ex.Message + "; Or Invalid, missing, or misformatted Raw Material List: " + ex.Message + ". " + ex.InnerException?.Message + "</span>";
            }

        }

    }
}