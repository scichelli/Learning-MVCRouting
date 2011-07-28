using System.Web.Mvc;
using System.Web.Routing;

namespace Routing.SupportingPlayers
{
	public class CustomRouteApplication
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
			   "ViewConference",
			   "Conference/{confname}/{action}",
			   new { controller = "Conference", action = "Show" });

			routes.MapRoute(
				"Default", // Route name
				"{controller}/{action}/{id}", // URL with parameters
				new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
			);
		}
	}
}