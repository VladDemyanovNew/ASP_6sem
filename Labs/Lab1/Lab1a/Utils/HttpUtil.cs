using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab1a.Utils
{
    public static class HttpUtil
    {
        public static void OnError(HttpResponse response, int statusCode, string statusMessage)
        {
            response.ContentType = "text/plain";
            response.StatusCode = statusCode;
            response.Write($"Error: {statusMessage}");
            response.End();
        }
    }
}