# Exploring MVC's routing engine via unit tests #
This solution has two purposes, and so has two sections. The UI project and the Routing.Tests project make up one section. These give an example of a boilerplate MVC project, showing how routes are configured in Global.asax.cs, and its attendant unit test project. I kept these in here, separate from the other test project, because I wanted an example of how the routes registration would really work in the wild, and which assembly references would be needed (and which ones _not_ needed) in the test project.

The second section is the ExploringRoutesWithTests project, organized by one-test-fixture-per-theme, where I'm using unit tests to play what-if games with routing.

With thanks to 
 * Phil Haack: [http://haacked.com/archive/2007/12/17/testing-routes-in-asp.net-mvc.aspx](http://haacked.com/archive/2007/12/17/testing-routes-in-asp.net-mvc.aspx)
 * Scott Guthrie: [http://weblogs.asp.net/scottgu/archive/2007/12/03/asp-net-mvc-framework-part-2-url-routing.aspx](http://weblogs.asp.net/scottgu/archive/2007/12/03/asp-net-mvc-framework-part-2-url-routing.aspx)
 * Mike Hadlow: [http://mikehadlow.blogspot.com/2008/04/extension-properties-for-easy.html](http://mikehadlow.blogspot.com/2008/04/extension-properties-for-easy.html)

