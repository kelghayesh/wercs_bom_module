using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading.Tasks;
using SDS.SDSRequest.Models;
using SDS.SDSRequest.Controllers;
using System.Configuration;
using PG.Gps.DepotClient;
using PG.Gps.DepotClient.Model;
using System.Text.RegularExpressions;
//using System.Web.Mvc;

namespace SDS.SDSRequest.DepotClientPage
{
    public partial class pass_comp_req : System.Web.UI.Page
    {
        public string CurUser = "";
        //public int ExESSQueryRowCount = 0;
        //protected string PassResultDisplay = "";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BindProductGrid(List<FindPartKeyResult> wercsResults)
        {
            //if (wercsResults == null) return;
            if (wercsResults == null) wercsResults = new List<FindPartKeyResult>(0);

            grdvPassResult.AutoGenerateColumns = true;
            grdvPassResult.DataSource = wercsResults;
            grdvPassResult.DataBind();
        }

        protected void BindProductGrid(List<DepotPart> wercsResults)
        {
            //if (wercsResults == null) return;
            if (wercsResults == null) wercsResults = new List<DepotPart>(0);

            grdvPassResult.AutoGenerateColumns = true;
            grdvPassResult.DataSource = wercsResults;
            grdvPassResult.DataBind();
        }
        protected void BindProductFormulaGrid(List<DepotCompositionPart> wercsResults)
        {
            //if (wercsResults == null) return;
            if (wercsResults == null) wercsResults = new List<DepotCompositionPart>(0);

            grdvPassResult.AutoGenerateColumns = true;
            grdvPassResult.DataSource = wercsResults;
            grdvPassResult.DataBind();
        }

        protected void cmdStageGCASFormulae_Click(object sender, EventArgs e)
        {
            //string SourceSystem = "Depot";
            string SourceSystem = ConfigurationManager.AppSettings["SourceSystem"];
            string productKeys = txtGCASCodes.Value; //95413901 95515790 95716177 95773437 95912053

            productKeys = Regex.Replace(productKeys, @"\r\n?|\n", ","); //replace CR with comma
            productKeys = Regex.Replace(productKeys, @"\s+", ""); //remove all spaces

            int lowerLimitValidation = 0, upperLimitValidation=0;
            if (Int32.TryParse(txtLowerLimitValidation.Value.ToString(), out lowerLimitValidation) && Int32.TryParse(txtUpperLimitValidation.Value.ToString(), out upperLimitValidation))
            {
                //ProcessDepotRequest(SourceSystem, productKeys, lowerLimitValidation, upperLimitValidation, chkRMOnly.Checked);
                ProcessDepotRequest(SourceSystem, productKeys, lowerLimitValidation, upperLimitValidation, chkAllowResultWhenBosErrors.Checked);
            }
        }

        protected void cmdSearchStaged_Click(object sender, EventArgs e)
        {
            //string SourceSystem = "Depot";
            string SourceSystem = ConfigurationManager.AppSettings["SourceSystem"];
            string productKeys = txtGCASCodes.Value; //95413901 95515790 95716177 95773437 95912053

            productKeys = Regex.Replace(productKeys, @"\r\n?|\n", ","); //replace CR with comm
            productKeys = Regex.Replace(productKeys, @"\s+", ""); //remove all spaces
            if (!string.IsNullOrEmpty(productKeys))
                Response.Redirect("~/FormulaImportRequest/RequestQueueSearchIndex?args=" + productKeys + "?"+ SourceSystem);


        /*
            var controller = DependencyResolver.Current.GetService<FormulaImportRequestController>();
            controller.ControllerContext = new ControllerContext(this.Request.RequestContext, controller);
            controller.ActionInvoker.InvokeAction(controller.ControllerContext, "RequestQueueIndex(id = 0, productKeyList='90726028,90699482,91186728,90799531', sourceSystem='Depot'");
        */    

            //window.location = "FormulaImportRequest/RequestQueueSearchByKeyList/" + productKeys + "?sourceSystem=Depot";
            //FormulaImportRequestController c = new FormulaImportRequestController();
            //return c.RequestQueueSearchByKeyList(productKeys, SourceSystem);
        }


        void DisplayRequestResult(List<DepotOperationResultStatus> result)
        {
            PassResultDisplayDiv.InnerHtml = "";
            string processedPartKey = "", successMessage="";
            foreach (DepotOperationResultStatus r in result)
            {
                processedPartKey = string.IsNullOrEmpty(r.ProcessedPartKey) ? "PartKey Not Processed" : r.ProcessedPartKey;
                successMessage = string.IsNullOrEmpty(r.SuccessMessage) ? "Blank Success Message" : r.SuccessMessage;

                PassResultDisplayDiv.InnerHtml += " >" + r.RequestId + " - " + r.RequestedPart + " - " + processedPartKey + " - ResultCount=" + r.ResultCount + " - " + successMessage + " - " + r.ErrorMessage;
            }
        }

        void DisplayDepotRequestParts(List<DepotPart> bestparts)
        {
            if (bestparts == null) bestparts = new List<DepotPart>(0);

            grdvPassResult.AutoGenerateColumns = true;
            grdvPassResult.DataSource = bestparts;
            grdvPassResult.DataBind();

        }

        protected async void ProcessDepotRequest(string SourceSystem, string productKeys, int formulaLowerLimitValidation, int formulaUpperLimitValidation, bool AllowResultWhenBosErrors)
        //protected void ProcessDepotRequest(string SourceSystem, string productKeys, int formulaLowerLimitValidation, int formulaUpperLimitValidation, bool PullRMOnly)
        {
            List<DepotOperationResultStatus> ret;
            if (String.IsNullOrEmpty(productKeys))
            {
                PassResultDisplayDiv.InnerHtml = "Invalid or blank Product Keys";
                return;
            }
            //bool RMRequestValidated = false;
            //bool  AllowResultWhenBosErrors = false;
            //if (PullRMOnly == true) RMRequestValidated = IsRMRequest(SourceSystem, productKeys);

            //if (PullRMOnly==false || (PullRMOnly==true && RMRequestValidated))
            //{
            ret = await PassFormulaController.ProcessDepotRequest(productKeys, SourceSystem, AllowResultWhenBosErrors, formulaLowerLimitValidation, formulaUpperLimitValidation);
            DisplayRequestResult(ret);
            //}
        }
        protected bool IsRMRequest(string SourceSystem, string productKeys)
        {
            bool ret = true;

            List<DepotOperationResultStatus> part_types = PassFormulaController.GetPartTypes(productKeys, SourceSystem);

            PassResultDisplayDiv.InnerHtml = "Error encountered: ";
            foreach (DepotOperationResultStatus part_type in part_types)
            {
                if (!(part_type.PartTypeName.Equals("RMP") || part_type.PartTypeName.Equals("Raw Material")))
                {
                    PassResultDisplayDiv.InnerHtml += part_type.RequestedPart + " is not RM, it is " + part_type.PartTypeName + ".   ";

                    ret = false;

                }

            }
            return ret;
        }

    }
}