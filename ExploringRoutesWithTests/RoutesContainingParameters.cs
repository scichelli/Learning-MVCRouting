using System;
using System.Web.Mvc;
using System.Web.Routing;
using NUnit.Framework;

namespace ExploringRoutesWithTests
{
	[TestFixture]
	public class RoutesContainingParameters : RoutingTestBase
	{
		protected override Action RouteRegistration
		{
			get { return () => RoutesContainingParametersApplication.RegisterRoutes(Routes); }
		}

		[Test]
		public void Find_a_conference_by_name()
		{
			AssertRoute("~/conference/mvc-bootcamp", new { controller = "Conference", action = "Show", confname = "mvc-bootcamp"});
		}

		[Test]
		public void Specify_a_different_action()
		{
			AssertRoute("~/conference/mvc-bootcamp/edit", new { controller = "Conference", action = "Edit", confname = "mvc-bootcamp" });
		}

		[Test]
		public void Default_route_still_works()
		{
			AssertRoute("~/product/show/17", new { controller = "Product", action = "Show", id = "17" });
		}
	}

	public class RoutesContainingParametersApplication
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