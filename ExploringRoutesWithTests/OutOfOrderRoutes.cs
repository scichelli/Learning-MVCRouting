using System;
using System.Web.Mvc;
using System.Web.Routing;
using NUnit.Framework;

namespace ExploringRoutesWithTests
{
	public class OutOfOrderRoutes : RoutingTestBase
	{
		protected override Action RouteRegistration
		{
			get { return () => OutOfOrderRoutesApplication.RegisterRoutes(Routes); }
		}

		[Test]
		public void Find_a_conference_by_name_doesnt_work_as_expected()
		{
			//It interprets the second token as the action, not the conference name.
			AssertRoute("~/conference/mvc-bootcamp", new { controller = "Conference", action = "mvc-bootcamp" });
		}

		[Test]
		public void Specify_a_different_action_doesnt_work_as_expected()
		{
			//It interprets the second token as the action and the third as the ID, 
			//instead of conference name and action.
			AssertRoute("~/conference/mvc-bootcamp/edit", new { controller = "Conference", action = "mvc-bootcamp", id = "edit" });
		}

		[Test]
		public void Default_route_still_works()
		{
			AssertRoute("~/product/show/17", new { controller = "Product", action = "Show", id = "17" });
		}
	}

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