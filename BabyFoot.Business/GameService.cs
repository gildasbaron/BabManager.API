using BabyFoot.Business.Contract;
using BabyFoot.Common.Disp;
using BabyFoot.Common.Log;
using BabyFoot.Dal.Contract;

namespace BabyFoot.Business
{
    public class GameService :  IGameService
    {
        private readonly IGameDataService _gameDataService;
        private readonly IDispatcher _dispatcher;
        private readonly ILogger _logger;

        public GameService(
            IGameDataService gameDataService,
            IDispatcher dispatcher,
            ILogger logger)
        {
            this._gameDataService = gameDataService;
            _dispatcher = dispatcher;
            this._logger = logger;
        }

        public void CreateGame(string name)
        {
            _logger.Log("business about creating a game");
            _gameDataService.Create(name);
            _dispatcher.Dispatch(name);
        }

        public void DeleteGame(string name)
        {
        }

        public void GetGame(string name)
        {
        }

        public void GetAllGames()
        {
        }
    }
}
