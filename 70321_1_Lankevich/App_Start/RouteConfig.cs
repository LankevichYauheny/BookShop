using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace _70321_1_Lankevich
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "menu",
                url: "menu",
                defaults: new { controller = "Film", action = "List", page = 1, group = (string)null }
            );

            routes.MapRoute(
                name: "menuPage",
                url: "menu/page{page}",
                defaults: new { controller = "Film", action = "List", group = (string)null },
                constraints: new { page = @"\d+" }
            );

            routes.MapRoute(
                name: "group",
                url: "menu/{group}",
                defaults: new { controller = "Film", action = "List", page = 1 }
            );

            routes.MapRoute(
                name: "groupPage",
                url: "menu/{group}/page{page}",
                defaults: new { controller = "Film", action = "List" },
                constraints: new { page = @"\d+" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
