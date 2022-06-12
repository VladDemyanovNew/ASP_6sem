using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab5a.Controllers
{
    [RoutePrefix("V2")]
    public class MResearchController : Controller
    {
        public ActionResult M01()
        {
            return Content("GET:M01");
        }

        public ActionResult M02()
        {
            return Content("GET: M02");
        }

        public ActionResult M03()
        {
            return Content("GET:M03");
        }

        public ActionResult MXX()
        {
            return Content("MXX");
        }
    }
}
