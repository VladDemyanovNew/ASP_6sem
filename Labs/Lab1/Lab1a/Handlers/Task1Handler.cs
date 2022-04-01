using System;
using System.Web;

namespace Lab1a.Handlers
{
    public class Task1Handler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }

        /// <summary>
        /// request.Params - словарь включающий комбинацию QueryString, Form, Cookies, ServerVariables
        /// </summary>
        public void ProcessRequest(HttpContext context)
        {
            var request = context.Request;
            var response = context.Response;
            var paramA = request.QueryString.Get("ParamA");
            var paramB = request.QueryString.Get("ParamB");

            response.ContentType = "text/plain";
            response.Write($"GET-Http-DVR:ParamA={paramA},ParamB={paramB}");
        }
    }
}
