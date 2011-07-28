using System;
using NUnit.Framework;
using UI;

namespace Routing.Tests.UI
{
	[TestFixture]
	public class RouteTests : RoutingTestBase
	{
		protected override Action RouteRegistration
		{
			get { return () => MvcApplication.RegisterRoutes(Routes); }
		}

		[Test]
		public void Default_route_with_a_controller_and_an_action()
		{
			AssertRoute("~/product/list", new { controller = "Product", action = "List"});
		}

		[Test]
		public void Default_route_with_additional_id()
		{
			AssertRoute("~/product/show/17", new { controller = "Product", action = "Show", id = "17" });
		}

		[Test, Explicit("Expected failure, because ID in route is different from ID in assertion")]
		public void Id_in_url_is_mapped()
		{
			AssertRoute("~/product/show/17", new { controller = "Product", action = "Show", id = "25" });
		}

		[Test, Explicit("Expected failure, because an extra route segment has no token to be mapped into")]
		public void Too_many_parameters_does_not_match_route()
		{
			AssertRoute("~/product/show/17/extra", new { controller = "Product", action = "Show", id = "17" });
		}
	}
}
