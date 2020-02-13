using System;
using System.Linq;
using System.Web.Http;
using BabyFoot.Common;
using BabyFoot.Common.Context;
using BabyFoot.Common.Log;
using Unity;
using Unity.Lifetime;

namespace BabyFoot.Api
{
    public static class UnityConfig
    {
        public static IUnityContainer Container;

        public static void RegisterComponents()
        {
            Container = new UnityContainer();
            Container.RegisterType<ILogger, Logger>(new HierarchicalLifetimeManager());
            Container.RegisterType<IRequestContextInfo, RequestContextInfo>(new HierarchicalLifetimeManager());
            Container.RegisterType<IApplicationContext, ApplicationContext>(new ContainerControlledLifetimeManager());

            RegisterAllRegistrationServices();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityResolver(Container);
        }

        private static void RegisterAllRegistrationServices()
        {
            var interfaceType = typeof(IRegistrationService);

            var all = AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => a.FullName.StartsWith("Baby"))
                .SelectMany(x => x.GetTypes())
                .Where(x => interfaceType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance);

            foreach (var o in all)
            {
                ((IRegistrationService) o).Register(Container);
            }
        }
    }
}