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
    public class ActionsController : ControllerBase
    {
        private readonly ILogger<ActionsController> _logger;

        public ActionsController(ILogger<ActionsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Actions> Get()
        {
          return ActionsDatabaseHandler.GetActions();
        }

        [HttpGet]
        [Route("/Actions/{HID}/{VillainID}/{GameID}/{TURNCOUNTER}")]
        public Actions GetIDGame(int HID, int VillainID, int GameID, int TURNCOUNTER) {
            return ActionsDatabaseHandler.GetIDActions(HID, VillainID, GameID, TURNCOUNTER);
        }

        [HttpPost]
        public void Post([FromBody]Actions a)
        {
            ActionsDatabaseHandler.PostActions(a);
        }
    }
}
