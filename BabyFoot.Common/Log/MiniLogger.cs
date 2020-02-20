using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyFoot.Common.Log
{
    public class DebugLooger : ILogger
    {
        public void Log(string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }
    }
}
