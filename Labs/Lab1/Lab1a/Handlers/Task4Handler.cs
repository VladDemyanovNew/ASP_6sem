using Lab1a.Utils;
using System;
using System.Web;

namespace Lab1a.Handlers
{
    public class Task4Handler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            var request = context.Request;
            var response = context.Response;

            var paramX = request.Form.Get("x");
            var paramY = request.Form.Get("y");

            if (String.IsNullOrEmpty(paramX))
            {
                HttpUtil.OnError(response, 400, "Параметр x не задан");
            }

            if (String.IsNullOrEmpty(paramY))
            {
                HttpUtil.OnError(response, 400, "Параметр y не задан");
            }

            if (!Int32.TryParse(paramX, out int x))
            {
                HttpUtil.OnError(response, 400, "Параметр x должен быть числом");
            }

            if (!Int32.TryParse(paramY, out int y))
            {
                HttpUtil.OnError(response, 400, "Параметр y должен быть числом");
            }

            var rc = x + y;

            response.ContentType = "text/plain";
            response.Write(rc);
            response.End();
        }
    }
}
