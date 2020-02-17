using BabyFoot.Common.Log;
using BabyFoot.Dal.Contract;

namespace BabyFoot.Dal
{
    public class GameDataService : IGameDataService
    {
        private readonly ILogger _logger;

        public GameDataService(ILogger logger)
        {
            _logger = logger;
        }

        public void Create(string name)
        {
            this._logger.Log($"{name} created ");
        }

        public void Delete(string name)
        {
            this._logger.Log($"Delete {name} ");
        }

        public void Ge(string name)
        {
            this._logger.Log($"Get {name}");
        }

        public void GetAll()
        {
            this._logger.Log($"GetAll games by ");
        }
    }
}
