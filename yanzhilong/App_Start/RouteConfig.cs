using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace yanzhilong
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] {"yanzhilong.Controllers"}
            );

            routes.MapRoute(
                 name: "Article_Category",
                 url: "{controller}/{action}/{CategoryID}",
                 namespaces: new[] { "yanzhilong.Controllers" }
             );

            routes.MapRoute(
                 name: "Article_Category_page",
                 url: "{controller}/{action}/{CategoryID}/{page}",
                 namespaces: new[] { "yanzhilong.Controllers" }
             );

        }
    }
}
