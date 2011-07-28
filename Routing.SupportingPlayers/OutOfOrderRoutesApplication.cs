using System.Web.Mvc;
using System.Web.Routing;

namespace Routing.SupportingPlayers
{
	public class OutOfOrderRoutesApplication
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.MapRoute(
				"Default", // Route name
				"{controller}/{action}/{id}", // URL with parameters
				new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
			);

			routes.MapRoute(
			   "ViewConference",
			   "Conference/{confname}/{action}",
			   new { controller = "Conference", action = "Show" });
		}
	}
}