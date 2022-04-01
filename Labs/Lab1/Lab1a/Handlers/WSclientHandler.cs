using System;
using System.IO;
using System.Web;

namespace Lab1a.Handlers
{
    public class WSclientHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            var request = context.Request;
            var response = context.Response;

            var exePath = AppDomain.CurrentDomain.BaseDirectory;
            var pathToFile = Path.Combine(exePath, "Views", "wsclient.html");

            response.ContentType = "text/html";
            response.WriteFile(pathToFile);
            response.End();
        }
    }
}
