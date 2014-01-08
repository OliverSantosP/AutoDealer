using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AutoDealer
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                "ModelosList",
                "Automovil/Modelos/List/{Id}",
                new { controller = "Home", action = "ModelosList", Id = "" }
            );


            routes.MapRoute(
                "FabricantesList",
                "Automovil/Fabricantes/List",
                new { controller = "Home", action = "FabricantesList" }
            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}