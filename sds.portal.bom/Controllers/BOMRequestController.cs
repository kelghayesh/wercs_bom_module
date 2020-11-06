using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using SDS.SDSRequest.Factory;
using SDS.SDSRequest.Models;
using PG.Gps.DepotClient.Model;
using PG.Gps.DepotClient;
using System.Text.RegularExpressions;
using SDS.SDSRequest.DAL;

namespace SDS.SDSRequest.Controllers
{
    public class BOMRequestController : Controller
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        private SDSRequestDbContext db = new SDSRequestDbContext();

        private static DepotAccessRecord depotAccessRecord = new DepotAccessRecord();
        private static string UpdatedBy;//= HttpContext.Current.User.Identity.Name.ToString();
        //private static System.Web.Routing.RequestContext _requestContext;
        private static System.Web.HttpContext _httpContext;
        // private static string url = HttpContext.Current.Request.Url.ToString();
        private static string SourceSystem = ConfigurationManager.AppSettings["SourceSystem"];

        public BOMRequestController()
        {
            //bool i = HttpContext.Request.IsAuthenticated;
            _httpContext = null;
        }

        //public BOMRequestController(System.Web.Routing.RequestContext requestContext)
        public BOMRequestController(System.Web.HttpContext httpContext)
        {
            //bool i = HttpContext.Request.IsAuthenticated;
            _httpContext = httpContext;
        }
        private static string GetCurrentUser()
        {
            //string url = HttpContext.Current.Request.Url.ToString();
            //string url = _requestContext?.HttpContext.Request.Url.ToString();
            string url = _httpContext.Request.Url.ToString();
            string curuser = null;

            if (url.Contains("localhost"))
                curuser = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            else
                //curuser = Controller.HttpContext.Current.User.Identity.Name.ToString();
                curuser = _httpContext.User.Identity.Name.ToString();

            return curuser.Substring(curuser.IndexOf('\\') + 1);
        }

        public ActionResult BOMRequestQueueIndex(int id, string productKeyList, string sourceSystem)
        {
            if (string.IsNullOrEmpty(productKeyList))
                return View(DbEfFactory.GetBOMRequestQueue(id, sourceSystem));
            else
                return View(DbEfFactory.GetFormulaImportRequestQueueByProductList(productKeyList, sourceSystem));
        }

        public ActionResult BOMRequestIndex()
        {
            //return View(db.FormulaImportRequestListItems.ToList());
            return View(DbEfFactory.GetFormulaImportRequestsList(FormulaImportRequestType.BOM_REQUEST));
        }

        public List<DepotOperationResultStatus> ProcessDepotBOMRequest(string targetFormulaKey, int rmFormulaLowerLimitValidation, int rmFormulaUpperLimitValidation, List<BOMIngredient> bomIngredients, int? parentBOMRequestId=0, string BOMRequestTargetKey=null)
        {
            //assumptions: all formulations are in WERCS, so we don't need to go to Depot for anything here.
            //if a formula for a material in the BOM isn't in WERCS, it should be imported into WERCS before starting the BOM formula request
            UpdatedBy = GetCurrentUser();

            //List<DepotOperationResultStatus> request_ret = new List<DepotOperationResultStatus>();
            //DepotOperationResultStatus r;
            //string[] lookupKeys = new string[bomIngredients.Count() - 1];

            //loop in get_bos_depot and see if there's errors

            string RequestSourceSystem = "WERCS";
            List<DepotOperationResultStatus> bos_ret = new List<DepotOperationResultStatus>();
            DepotOperationResultStatus savebom_ret = DbEfFactory.AddDepotBOMRequest(targetFormulaKey, bomIngredients, rmFormulaLowerLimitValidation, rmFormulaUpperLimitValidation, "BOM Request", UpdatedBy, RequestSourceSystem);
            bos_ret.Add(savebom_ret);

            List<DepotOperationResultStatus> get_bos_depot = new List<DepotOperationResultStatus>();
            string prodKeys="";
            bool depotLoadSuccess = true;

            if (savebom_ret.RequestId==0)
            {
                bos_ret.Add(new DepotOperationResultStatus { RequestId = 0, ErrorMessage = "Error saving BOM request." });
                return bos_ret;
            }

            List<BOMIngredient> depotParts = bomIngredients.Where(p => p.RMSource.ToLower().Contains("depot")).ToList<BOMIngredient>();
            if (depotParts?.Any() ?? false)
            {
                prodKeys = string.Join(",", depotParts.Select(a => a.RMKey.ToString()));
                get_bos_depot = PassFormulaController.ProcessDepotRequest(prodKeys, sourceSystem: "Depot", overrideBOSErrors: true, formulaLowerPercentValidation: 0, formulaUpperPercentValidation: 0, existingRequestId:0, parentBOMRequestId: savebom_ret.RequestId, BOMRequestTargetKey: targetFormulaKey);

                foreach (DepotOperationResultStatus ret in get_bos_depot)
                {
                    if (ret?.ErrorMessage?.Length > 0 || ret?.ResultCount == -1)
                    {
                        //bos_ret.Add(new DepotOperationResultStatus { RequestId = savebom_ret.RequestId, ErrorMessage = "Error Importing BOS for " + prodKeys + " from Depot." });
                        bos_ret.Add(ret);
                        depotLoadSuccess = false;
                    }
                }
                if (depotLoadSuccess)
                {
                    bos_ret.Add(new DepotOperationResultStatus { RequestId = savebom_ret.RequestId, SuccessMessage = "Import of BOS for " + prodKeys + " from Depot completed successfully." });
                }
                else
                {
                    return bos_ret;
                }
            }
            //if no depotParts or depotParts processed successfully 
            //comment out following until later...
            
            
            if (depotLoadSuccess)  //if no depotParts or depotParts processed successfully 
            {
                string processBOMRequest = ConfigurationManager.AppSettings["ProcessBOMRequest"] ?? "true";
                if (string.Compare(processBOMRequest, "true", ignoreCase:true) == 0)
                {
                    DepotOperationResultStatus savebomdetail_ret = DbEfFactory.ProcessBOMRequest(savebom_ret.RequestId, targetFormulaKey, "Wercs");
                    DbEfFactory.StartDTE();  //this may already be incoporated in StageBOMRequest
                    bos_ret.Add(savebomdetail_ret);
                }
            }
            
            //end comment
            return bos_ret;
        }

        // GET: BOMRequest
        public ActionResult Index()
        {
            return View();
        }
    }
}