using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using NUnit.Framework;
using Rhino.Mocks;

namespace ExploringRoutesWithTests
{
	public abstract class RoutingTestBase
	{
		protected RouteCollection Routes;
		protected abstract Action RouteRegistration { get; }

		[SetUp]
		public void Setup()
		{
			Routes = new RouteCollection();
			RouteRegistration();
		}

		protected void AssertRoute(string url, object expectations)
		{
			var httpContext = MockRepository.GenerateStub<HttpContextBase>();
			httpContext.Stub(c => c.Request.AppRelativeCurrentExecutionFilePath).Return(url);
			RouteData routeData = Routes.GetRouteData(httpContext);
			Assert.IsNotNull(routeData, "Expected to find route");
			foreach (var property in GetProperties(expectations))
			{
				Assert.IsTrue(routeData.Values[property.Name].ToString()
								.Equals(property.Value.ToString(),
										StringComparison.OrdinalIgnoreCase),
							  String.Format("Expected '{0}' for '{1}', but found '{2}'",
											property.Value, property.Name, routeData.Values[property.Name]));

			}
		}

		private IEnumerable<NameValue<string, object>> GetProperties(object item)
		{
			return item.GetType().GetProperties()
				.Select(p => new NameValue<string, object>(p.Name, () => p.GetValue(item, null)));
		}

		private class NameValue<TName, TValue>
		{
			public TName Name { get; private set; }
			public TValue Value { get { return _valueFunction(); } }
			private readonly Func<TValue> _valueFunction;

			public NameValue(TName name, Func<TValue> valueFunction)
			{
				Name = name;
				_valueFunction = valueFunction;
			}
		}
	}
}