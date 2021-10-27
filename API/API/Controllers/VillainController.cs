// using System;
// using System.Collections;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Cors;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Cors;

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
        [EnableCors("MyPolicy")]
        [HttpGet]
        public IEnumerable<Villain> GetVillains()
        {
          return VillainDatabaseHandler.GetVillains();
        }
        [EnableCors("MyPolicy")]
        [HttpGet]
        [Route("/Villain/{VillainID}")]
        public Villain GetIDVillains(int VillainID)
        {
            return VillainDatabaseHandler.GetIDVillain(VillainID);
        }
        [EnableCors("MyPolicy")]
        [HttpPost]
        public void Post([FromBody]Villain v)
        {
            VillainDatabaseHandler.PostVillain(v);
        }
        [EnableCors("MyPolicy")]
        [HttpPut]
        public void Put([FromBody]Villain v)
        {
            VillainDatabaseHandler.PutVillain(v);
            
        }
        [EnableCors("MyPolicy")]
        [HttpDelete("{VillainID}")]
        public void Delete(int VillainID)
        {
            System.Console.WriteLine("Deleting Villain with ID: " + VillainID);
            VillainDatabaseHandler.DeleteVillain(VillainID);
            
        }
        
    }



    }