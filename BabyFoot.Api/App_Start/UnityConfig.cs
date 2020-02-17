using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BabyFoot.Business;
using BabyFoot.Business.Contract;
using BabyFoot.Common;
using BabyFoot.Common.Context;
using BabyFoot.Common.Disp;
using BabyFoot.Common.Log;
using BabyFoot.Dal;
using BabyFoot.Dal.Contract;
using Unity;
using Unity.Injection;
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
            Container.RegisterType<ILogger, DebugLooger>("Logger2",new HierarchicalLifetimeManager());
            Container.RegisterType<IRequestContextInfo, RequestContextInfo>(new HierarchicalLifetimeManager());
            Container.RegisterType<IApplicationContext, ApplicationContext>(new ContainerControlledLifetimeManager());

            Container.RegisterType<IGameService, GameService>(new HierarchicalLifetimeManager());
            Container.RegisterType<IGameDataService, GameDataService>(new HierarchicalLifetimeManager(), new InjectionConstructor(new ResolvedParameter<ILogger>("Logger2")));

         
            for (int i = 0; i < 5; i++)
                Container.RegisterType<IBroadcaster, Broadcaster>($"{i}", new InjectionConstructor(new Object[] {new ResolvedParameter<ILogger>("Logger2"), $"BC{i}"}));
            
            Container.RegisterType<IList<IBroadcaster>, IBroadcaster[]>();
            Container.RegisterType<IDispatcher, Dispatcher>();

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