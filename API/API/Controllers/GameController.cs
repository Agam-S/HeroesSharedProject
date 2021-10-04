using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly ILogger<GameController> _logger;

        public GameController(ILogger<GameController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Game> Get()
        {
          return GameDatabaseHandler.GetGames();
        }

        [HttpGet]
        [Route("/Game/{GameID}")]
        public Game GetIDGame(int GameID) {
            return GameDatabaseHandler.GetIDGame(GameID);
        }

        [HttpPost]
        public void Post([FromBody]Game g)
        {
            GameDatabaseHandler.PostGame(g);
        }

    }
}
