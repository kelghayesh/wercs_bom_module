using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SDS.SDSRequest.DAL;
using SDS.SDSRequest.Models;
using SDS.SDSRequest.Factory;
using System.IO;
using ClosedXML.Excel;

namespace SDS.SDSRequest.Controllers
{
    public class FormulaImportRequestController : Controller
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        private SDSRequestDbContext db = new SDSRequestDbContext();

        // GET: FormulaImportRequest
        //[Authorize]
        public ActionResult DepotRequestIndex()
        {
            //return View(db.FormulaImportRequestListItems.ToList());
            return View(DbEfFactory.GetFormulaImportRequestsList(FormulaImportRequestType.DEPOT_REQUEST));
        }


        public RedirectResult RedirectToBOMStatusPage(string RequestId)
        {
            return Redirect("~/pages/target_bom_result.aspx?RequestId="+ RequestId+ "&targetFormulaKey=none");
        }
        
        //[Authorize, ValidateAntiForgeryToken]
        public ActionResult RequestQueueIndex(int id, string productKeyList, string sourceSystem)
        {
            if (string.IsNullOrEmpty(productKeyList))
                return View(DbEfFactory.GetFormulaImportRequestQueue(id, sourceSystem));
            else
                return View(DbEfFactory.GetFormulaImportRequestQueueByProductList(productKeyList, sourceSystem));
        }

        /*
        public ActionResult BOMRequestIndex()
        {
            //return View(db.FormulaImportRequestListItems.ToList());
            return View(DbEfFactory.GetFormulaImportRequestsList(FormulaImportRequestType.BOM_REQUEST));
        }

        public ActionResult BOMRequestQueueIndex(int id, string productKeyList, string sourceSystem)
        {
            if (string.IsNullOrEmpty(productKeyList))
                return View(DbEfFactory.GetBOMRequestQueue(id, sourceSystem));
            else
                return View(DbEfFactory.GetFormulaImportRequestQueueByProductList(productKeyList, sourceSystem));
        }
        */

        [HttpPost]
        public FileResult RequestQueueExport(int id, string sourceSystem)
        {

            DataTable dt = DbEfFactory.GetFormulaImportResultReport(id, sourceSystem);
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "RequestReport_" + id.ToString() + ".xlsx");
                }
            }
        }

        //[HttpPost]
        public ActionResult RequestQueueSearchIndex(string args)
        {
            string ProductKeyList = args.Substring(0, args.IndexOf("?"));
            string SourceSystem = args.Substring(args.IndexOf("?") + 1, args.Length - (args.IndexOf("?") + 1));

            /*
            var controller = DependencyResolver.Current.GetService<FormulaImportRequestController>();
            controller.ControllerContext = new ControllerContext(this.Request.RequestContext, controller);

            //Call your method
            ActionInvoker.InvokeAction(controller.ControllerContext, "RequestQueueIndex");
            */
            return RedirectToAction("RequestQueueIndex", new { id = 0, productKeyList = ProductKeyList, sourceSystem = SourceSystem });

            //ProductKeyList="90721797,91623930?sourceSystem=Depot"
            //need to make it one parameter, parse the one parameter into ProductKeyList and SourceSystem and call below:
            //return View(DbEfFactory.GetRequestQueueSearch(ProductKeyList, SourceSystem));
        }

        //[Authorize, ValidateAntiForgeryToken]
        public ActionResult RequestActivitiesIndex(int id)
        {
            return View(DbEfFactory.GetFormulaImportRequestActivities(id));
        }

        public ActionResult DeleteAction(bool confirm, int id, string SourceSystem)
        {
            if (confirm)
            {
                DbEfFactory.DeleteDepotFormulaRequest(id, SourceSystem);
            }

            return RedirectToAction("Index");
        }

        //[Authorize(Roles = "admin")]
        public ActionResult StageBOMRequest(bool confirm, int id, string SourceSystem)
        {
            if (confirm)
            {
                DbEfFactory.ProcessBOMRequest(id, "", SourceSystem);
            }

            //return RedirectToAction("RequestQueueIndex");
            return RedirectToAction("Index");
        }

        public ActionResult RequestQueueItemBOSIndex(int RequestQueueId)
        {
            return View(DbEfFactory.GetRequestQueueItemBOS(RequestQueueId));
        }


        public ActionResult RequestQueueItemMessagesIndex(int RequestQueueId)
        {
            return View(DbEfFactory.GetRequestQueueItemMessages(RequestQueueId));
        }

        // GET: FormulaImportRequest/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormulaImportRequestListItem formulaImportRequestListItem = db.FormulaImportRequestListItems.Find(id);
            if (formulaImportRequestListItem == null)
            {
                return HttpNotFound();
            }
            return View(formulaImportRequestListItem);
        }

        // GET: FormulaImportRequest/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FormulaImportRequest/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RequestId,SourceSystem,RequestStatus,UpdatedBy,UpdatedDate")] FormulaImportRequestListItem formulaImportRequestListItem)
        {
            if (ModelState.IsValid)
            {
                db.FormulaImportRequestListItems.Add(formulaImportRequestListItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(formulaImportRequestListItem);
        }

        // GET: FormulaImportRequest/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormulaImportRequestListItem formulaImportRequestListItem = db.FormulaImportRequestListItems.Find(id);
            if (formulaImportRequestListItem == null)
            {
                return HttpNotFound();
            }
            return View(formulaImportRequestListItem);
        }

        // POST: FormulaImportRequest/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RequestId,SourceSystem,RequestStatus,UpdatedBy,UpdatedDate")] FormulaImportRequestListItem formulaImportRequestListItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formulaImportRequestListItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(formulaImportRequestListItem);
        }

        // GET: FormulaImportRequest/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormulaImportRequestListItem formulaImportRequestListItem = db.FormulaImportRequestListItems.Find(id);
            if (formulaImportRequestListItem == null)
            {
                return HttpNotFound();
            }
            return View(formulaImportRequestListItem);
        }

        // POST: FormulaImportRequest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FormulaImportRequestListItem formulaImportRequestListItem = db.FormulaImportRequestListItems.Find(id);
            db.FormulaImportRequestListItems.Remove(formulaImportRequestListItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
