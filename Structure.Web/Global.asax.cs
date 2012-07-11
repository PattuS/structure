using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Structure.Web
{

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // ex: /contacts/{id}/edit
            // ex: /clients/{id}
            routes.MapRoute(
                "Actions",
                "{controller}/{id}/{action}",
                new { controller = "Public", action = "Index" },
                new { id = @"\d+" }
            );

            // ex: /contacts/new
            // ex: /clients
            routes.MapRoute(
                "Default",
                "{controller}/{action}",
                new { controller = "Public", action = "Index" }
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

#if DEBUG
            // enable test data for debug
            System.Data.Entity.Database.SetInitializer<Structure.Data.ModelContext>(new Structure.DataFixtures.ModelDataInitializer());
#else
            // disable test data for production
            System.Data.Entity.Database.SetInitializer<Structure.Data.ModelContext>(null);
#endif

            Bootstrapper.Initialise();

        }

    }
}