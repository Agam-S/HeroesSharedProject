using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
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
        [EnableCors("MyPolicy")]
        [HttpGet]
        public IEnumerable<Game> Get()
        {
          return GameDatabaseHandler.GetGames();
        }
        [EnableCors("MyPolicy")]
        [HttpGet]
        [Route("/Game/{GameID}")]
        public Game GetIDGame(int GameID) {
            return GameDatabaseHandler.GetIDGame(GameID);
        }
        [EnableCors("MyPolicy")]
        [HttpPost]
        public void Post([FromBody]Game g)
        {
            GameDatabaseHandler.PostGame(g);
        }

    }
}
