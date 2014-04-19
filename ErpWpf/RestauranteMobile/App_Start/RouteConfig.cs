using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RestauranteMobile
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            AddRoutesPedido(routes);
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }

        private static void AddRoutesPedido(RouteCollection routes)
        {
            routes.MapRoute(
                name: "NovoPedido",
                url:"novo_pedido",
                defaults: new { controller = "Pedido", action = "NovoPedido" }
                );
        }
    }
}
