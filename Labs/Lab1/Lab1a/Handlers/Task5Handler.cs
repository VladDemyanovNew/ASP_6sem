using Lab1a.Utils;
using System;
using System.IO;
using System.Web;

namespace Lab1a.Handlers
{
    public class Task5Handler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            var request = context.Request;
            var response = context.Response;

            switch (request.HttpMethod)
            {
                case "GET":
                    onGet(request, response);
                    break;
                case "POST":
                    onPost(request, response);
                    break;
                default:
                    HttpUtil.OnError(response, 504, "Метод не поддерживатеся сервером");
                    break;
            }
        }

        private void onGet(HttpRequest request, HttpResponse response)
        {
            var exePath = AppDomain.CurrentDomain.BaseDirectory;
            var pathToFile = Path.Combine(exePath, "Views", "task5.html");

            response.ContentType = "text/html";
            response.WriteFile(pathToFile);
            response.End();
        }

        private void onPost(HttpRequest request, HttpResponse response)
        {
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

            var result = x * y;

            response.ContentType = "application/json";
            response.Write(result);
            response.End();
        }
    }
}
