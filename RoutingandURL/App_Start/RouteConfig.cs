using System.Web.Mvc;
using System.Web.Routing;

namespace RoutingandURL
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Enable attribute routing for controllers and actions
            routes.MapMvcAttributeRoutes();

            // Define a custom route with parameters
            routes.MapRoute(
                name: "ProductDetails",
                url: "Products/{category}/{id}",
                defaults: new { controller = "Product", action = "Details", id = UrlParameter.Optional },
                constraints: new { id = @"\d+" } // ID must be a number
            );

            // Define a custom route with query string handling
            routes.MapRoute(
                name: "Search",
                url: "Search",
                defaults: new { controller = "Product", action = "Search" }
            );

            // Default route pattern
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
