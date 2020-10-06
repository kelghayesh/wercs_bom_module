using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SDS.SDSRequest.Factory;
using SDS.Portal.Web.Models;
using SDS.SDSRequest.Controllers;

namespace SDS.Portal.Web.pages
{
    public partial class target_bom_result : System.Web.UI.Page
    {
        protected void BindBOMResultHeaderGrid(List<BOMRequestResultHeader> bomResultHeader)
        {
            //if (wercsResults == null) return;
            if (bomResultHeader == null) bomResultHeader = new List<BOMRequestResultHeader>(0);

            grdvTargetBOMHeaderResult.AutoGenerateColumns = true;
            grdvTargetBOMHeaderResult.DataSource = bomResultHeader;
            grdvTargetBOMHeaderResult.DataBind();

        }

        protected void BindBOMResultErrorDetailGrid(List<BOMRequestResultErrorDetail> bomResultErrorDetail)
        {
            //if (wercsResults == null) return;
            if (bomResultErrorDetail == null) bomResultErrorDetail = new List<BOMRequestResultErrorDetail>(0);

            grdvTargetBOMDetailErrorResult.AutoGenerateColumns = true;
            grdvTargetBOMDetailErrorResult.DataSource = bomResultErrorDetail;
            grdvTargetBOMDetailErrorResult.DataBind();
        }

        private void DisplayBOMRequestResult(int RequestId, string targetFormulaKey)
        {

            if ((string.IsNullOrEmpty(targetFormulaKey)) || string.Compare(targetFormulaKey, "none") >= 0)
            {
                    targetFormulaKey = DbEfFactory.GetBOMRequestTargetKey(RequestId);
            }

            List<BOMRequestResultHeader> bomRequestResultHeader = DbEfFactory.GetBOMRequestResultHeader(RequestId, targetFormulaKey);
            if (bomRequestResultHeader.Count() > 0)
            {
                BindBOMResultHeaderGrid(bomRequestResultHeader);
            }
            List<BOMRequestResultErrorDetail> bomRequestResultErrorDetail = DbEfFactory.GetBOMRequestResultErrorDetail(RequestId, targetFormulaKey);
            htmlRequestId.Value = RequestId.ToString(); //bomRequestResultHeader[0].RequestId.ToString();
            htmlTargetFormulaKey.Value = targetFormulaKey; // bomRequestResultHeader[0].TargetKey;

            BindBOMResultErrorDetailGrid(bomRequestResultErrorDetail);
            lblBOMResultLabel.Text = "BOM Generation Request Result for " + targetFormulaKey + ": ";

        }

        protected void cmdStartDTE_click(object sender, EventArgs e)
        {
            PassFormulaController.StartDTE();

        }

        protected void cmdProcessBOMRequest_click(object sender, EventArgs e)
        {
            int requestId = 0;

            if (Int32.TryParse(htmlRequestId.Value, out requestId))
            {
                //parsing attempt was successful
                string targetFormulaKey = htmlTargetFormulaKey.Value;

            }
            else cmdProcessBOMRequest.Disabled = true;

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string RequestId = Request.QueryString["RequestId"];
            string targetFormulaKey = Request.QueryString["targetFormulaKey"];

            int requestId;
            if (Int32.TryParse(RequestId, out requestId))
            {
                DisplayBOMRequestResult(requestId, targetFormulaKey);
            }
        }
    }
}