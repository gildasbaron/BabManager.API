using System.Collections.Generic;

namespace BabyFoot.Common.Disp
{
    public class Dispatcher : IDispatcher
    {
        private readonly IList<IBroadcaster> _broadcasters;

        public Dispatcher(IBroadcaster[] broadcasters)
        {
            _broadcasters = broadcasters;
        }

        public void Dispatch( string what)
        {
            foreach (var broadcaster in _broadcasters)
            {
                broadcaster.Broadcast(what);
            }
        }
    }
}
