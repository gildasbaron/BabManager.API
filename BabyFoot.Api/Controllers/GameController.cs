using System.Web.Http;
using BabyFoot.Business.Contract;
using BabyFoot.Common.Log;

namespace BabyFoot.Api.Controllers
{
    public class GameController : ApiController
    {
        private readonly IGameService _gameService;
        private readonly ILogger _logger;

        public GameController(IGameService gameService, ILogger logger)
        {
            this._gameService = gameService;
            this._logger = logger;
        }

        [HttpGet]
        [Route("api/Game/{name}")]
        public void CreateNewGame([FromUri]string name)
        {
            _logger.Log($"api/Game/{name}");
            _gameService.CreateGame(name);
        }

        [HttpGet]
        [Route("api/Games/All")]
        public string GetAllGames()
        {
            return "lkjkjlkkj";
        }
    }
}
