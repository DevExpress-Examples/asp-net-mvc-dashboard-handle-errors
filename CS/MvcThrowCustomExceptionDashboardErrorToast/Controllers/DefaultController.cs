using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DevExpress.DashboardCommon;

namespace MvcThrowCustomExceptionDashboardErrorToast.Controllers {

    public class DefaultController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}