using Lab5b.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Lab5b.Controllers
{
    public class AResearchController : Controller
    {
        [AAFilter]
        [Route("aresearch/aa")]
        public void AA()
        {
            Response.Write("AA");
        }

        [ARFilter]
        [Route("aresearch/ar")]
        public ActionResult AR()
        {
            Response.Write("AR");
            return View();
        }

        [AEFilter]
        [Route("aresearch/ae")]
        public void AE()
        {
            throw new Exception("My exception");
            Response.Write("AE");
        }
    }
}