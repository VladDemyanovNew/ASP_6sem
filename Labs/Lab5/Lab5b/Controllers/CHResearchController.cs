using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Lab5b.Controllers
{
    public class CHResearchController : Controller
    {
        [HttpGet]
        [OutputCache(Duration = 5)]
        public void AD()
        {
            var result = new StringBuilder("AD");
            result.AppendLine(DateTime.UtcNow.ToString());
            Response.Write(result.ToString());
        }

        [HttpPost]
        [OutputCache(Duration = 7, VaryByParam = "x; y")]
        public void AP(int x, int y)
        {
            var result = new StringBuilder("AP ");
            result.AppendLine((x + y).ToString());
            Response.Write(result.ToString());
        }
    }
}