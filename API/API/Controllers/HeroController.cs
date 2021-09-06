using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HeroController : ControllerBase
    {
        static List<Hero> heroList = new List<Hero>() {
        
        new Hero(1, " Mr Swinburne", 0, 10, 2),
        new Hero(2, "Mrs Swinburne", 0, 5, 3),
        new Hero(3, "OOF", 5, 15, 3)
        
        };


        [HttpGet]
        public List<Hero> Get()
        {
          return heroList;
        }

        [HttpPost]
        public Hero Post([FromBody]Hero h){

            heroList.Add(h);
            return h;
            

        }
    }
}
