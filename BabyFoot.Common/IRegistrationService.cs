using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace BabyFoot.Common
{
    public interface IRegistrationService
    {
        void Register(IUnityContainer container);
    }
}
