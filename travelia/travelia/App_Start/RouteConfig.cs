using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace travelia
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

       
            routes.MapRoute(
             name: "Traveller",
             url: "traveller/{action}/{destination}",
             defaults: new { controller = "traveller", action = "travellerDestination" }
         );
            routes.MapRoute(
        name: "Travel guide",
        url: "{controller}/{action}/{division}",
        defaults: new { controller = "guider", action = "guiderDestinations" }
    );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Travelia", action = "Index", id = UrlParameter.Optional }
            );
          
        }
    }
}
