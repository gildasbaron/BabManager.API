using System.Threading;

namespace BabyFoot.Common.Context
{
    public class ApplicationContext : IApplicationContext
    {
        public string Data { get; set; }

        public int RequestCounter => _requestCounter;

        private int _requestCounter;

        public void IncrementCounter()
        {
            Interlocked.Increment(ref _requestCounter);
        }
    }
}
