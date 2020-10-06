using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDS.Portal.Web.Controllers
//namespace SDS.SDSRequest.Controllers
{
    public class AppMenusController : Controller
    {
        // GET: AppMenus
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}