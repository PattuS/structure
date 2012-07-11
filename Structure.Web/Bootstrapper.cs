using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc3;

namespace Structure.Web
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<Structure.Services.ILog, Structure.Web.Components.Logging.NLogger>();
            container.RegisterType<Structure.Services.IModelContext, Structure.Data.ModelContext>();
            container.RegisterType<Structure.Services.ModelService, Structure.Services.ModelService>();

            return container;
        }
    }
}