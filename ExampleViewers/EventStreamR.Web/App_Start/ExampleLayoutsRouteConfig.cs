using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BootstrapMvcSample.Controllers;
using EventStreamR.Web;
using EventStreamR.Web.Controllers;
using NavigationRoutes;

namespace BootstrapMvcSample
{
    public class ExampleLayoutsRouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapNavigationRoute<HomeController>("Dashboard", c => c.Index());

			routes.MapNavigationRoute<EventsController>("Events", c => c.Index());
			
			routes.MapNavigationRoute<AnalyticsController>("Analytics", c => c.Index());

			//routes.MapNavigationRoute<ExampleLayoutsController>("Example Layouts", c => c.Starter())
			//	  .AddChildRoute<ExampleLayoutsController>("Marketing", c => c.Marketing())
			//	  .AddChildRoute<ExampleLayoutsController>("Fluid", c => c.Fluid())
			//	  .AddChildRoute<ExampleLayoutsController>("Sign In", c => c.SignIn());
        }
    }
}
