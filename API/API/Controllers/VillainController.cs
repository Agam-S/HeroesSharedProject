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
    public class VillainController : ControllerBase
    {
        private readonly ILogger<VillainController> _logger;

        public VillainController(ILogger<VillainController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Villain> GetVillains()
        {
          return DatabaseHandler.GetVillains();
        }

        [HttpGet]
        [Route("/Villain/{VillainID}")]
        public Villain GetIDVillains(int VillainID)
        {
            return DatabaseHandler.GetIDVillain(VillainID);
        }

        [HttpPost]
        public void Post([FromBody]Villain v)
        {
            DatabaseHandler.PostVillain(v);
        }

        [HttpPut]
        public void Put([FromBody]Villain v)
        {
            DatabaseHandler.PutVillain(v);
            
        }
        
        [HttpDelete]
        public void Delete([FromBody]int VillainID)
        {
            DatabaseHandler.DeleteVillain(VillainID);
            
        }
        
    }



    }