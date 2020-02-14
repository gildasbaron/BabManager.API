using BabyFoot.Common;
using BabyFoot.Dal.Contract;
using Unity;
using Unity.Lifetime;

namespace BabyFoot.Dal.Registrations
{
    public class RegistrationService : IRegistrationService
    {
        public void Register(IUnityContainer container)
        {
            container.RegisterType<IGameDataService, GameDataService>(new HierarchicalLifetimeManager());
        }
    }
}
