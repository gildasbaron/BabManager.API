using BabyFoot.Business.Contract;
using BabyFoot.Common;
using Unity;
using Unity.Lifetime;

namespace BabyFoot.Business.Registrations
{
    public class RegistrationService : IRegistrationService
    {
        public void Register(IUnityContainer container)
        {
            container.RegisterType<IGameService, GameService>(new HierarchicalLifetimeManager());
        }
    }
}
