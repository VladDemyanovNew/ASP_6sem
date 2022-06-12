using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab5b.Filters
{
    public class AEFilterAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            filterContext.HttpContext.Response.Write(" OnException ");
            var viewResult = new ViewResult();
            viewResult.ViewName = "Error";
            filterContext.Result = viewResult;
            filterContext.ExceptionHandled = true;
        }
    }
}