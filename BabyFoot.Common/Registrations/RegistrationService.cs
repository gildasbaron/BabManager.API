using System;
using BabyFoot.Common.Log;
using Unity;

namespace BabyFoot.Common.Registrations
{
    class RegistrationService : IRegistrationService
    {
        public void Register(IUnityContainer container)
        {
         //   container.RegisterType<ILogger, Logger>();
        }
    }
}
