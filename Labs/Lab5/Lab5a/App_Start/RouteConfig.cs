using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Lab5a
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("C01_1", "CResearch", new { controller = "CResearch", action = "C01" });
            routes.MapRoute("C01_2", "CResearch/C01", new { controller = "CResearch", action = "C01" });
            routes.MapRoute("C02_1", "CResearch/C02", new { controller = "CResearch", action = "C02" });

            routes.MapRoute("M02_3", "V2", new { controller = "MResearch", action = "M02" });
            routes.MapRoute("M02_2", "V2/{controller}", new { controller = "MResearch", action = "M02" });
            routes.MapRoute("M03_3", "V3", new { controller = "MResearch", action = "M03" });
            routes.MapRoute("M03_2", "V3/{controller}/X/", new { controller = "MResearch", action = "M03" });
            routes.MapRoute("M01_1", "{controller}/{action}/1", new { controller = "MResearch", action = "M01" });
            routes.MapRoute("M01_2", "{controller}/{action}", new { controller = "MResearch", action = "M01" });
            routes.MapRoute("M01_3", "{controller}", new { controller = "MResearch", action = "M01" });
            routes.MapRoute("M01_4", "V2/{controller}/{action}", new { controller = "MResearch", action = "M01" });
            routes.MapRoute("M01_5", "V3/{controller}/X/{action}", new { controller = "MResearch", action = "M01" });
            routes.MapRoute("M02_1", "V2/{controller}/{action}", new { controller = "MResearch", action = "M02" });
            routes.MapRoute("M02_4", "V3/{controller}/X/{action}", new { controller = "MResearch", action = "M02" });
            routes.MapRoute("M02_5", "{controller}/{action}", new { controller = "MResearch", action = "M02" });
            routes.MapRoute("M03_1", "V3/{controller}/X/{action}", new { controller = "MResearch", action = "M03" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "MResearch", action = "M01" });
        }
    }
}
