using BabyFoot.Common.Log;

namespace BabyFoot.Common.Disp
{
    public class Broadcaster : IBroadcaster
    {
        private readonly ILogger _logger;
        private readonly string _name;

        public Broadcaster(ILogger logger, string name)
        {
            _logger = logger;
            _name = name;
        }

        public void Broadcast(string what)
        {
            _logger.Log($"{what} broadcast by {_name}");
        }
    }
}
