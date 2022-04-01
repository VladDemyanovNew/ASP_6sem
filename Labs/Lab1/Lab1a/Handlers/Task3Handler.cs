using System;
using System.Web;

namespace Lab1a.Handlers
{
    public class Task3Handler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            var request = context.Request;
            var response = context.Response;

            var paramA = request.Form.Get("ParamA");
            var paramB = request.Form.Get("ParamB");
            
            response.ContentType = "text/plain";
            response.Write($"PUT-Http-DVR:ParamA={paramA},ParamB={paramB}");
        }
    }
}
