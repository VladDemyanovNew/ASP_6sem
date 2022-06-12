using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Lab5b.Filters
{
    public class AAFilterAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write("After: Action has been executed");
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var result = new StringBuilder("Before:");
            result.AppendLine($"ActionName: {filterContext.ActionDescriptor.ActionName}<br>");
            result.AppendLine($"Result: {filterContext.Result}<br>");
            filterContext.HttpContext.Response.Write(result.ToString());
        }
    }
}