using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab5a.Controllers
{
    public class CResearchController : Controller
    {
        [AcceptVerbs("post", "get")]
        public ActionResult C01()
        {
            var httpContext = this.HttpContext;
            var request = httpContext.Request;
            ViewBag.Request = request;
            return View();
        }

        [AcceptVerbs("post", "get")]
        public ActionResult C02()
        {
            var httpContext = this.HttpContext;
            var response = httpContext.Response;
            ViewBag.Response = response;
            return View();
        }
    }
}