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
    public class HeroController : ControllerBase
    {
        private readonly ILogger<HeroController> _logger;

        public HeroController(ILogger<HeroController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Hero> Get()
        {
          return HeroDatabaseHandler.GetHero();
        }

        [HttpGet]
        [Route("/Hero/{HID}")]
        public Hero GetHero(int HID)
        {
            return HeroDatabaseHandler.GetIDHero(HID);
        }

        [HttpPost]
        public void Post([FromBody]Hero h)
        {
            HeroDatabaseHandler.PostHero(h);
        }

        [HttpPut]
        public void Put([FromBody]Hero h)
        {
            HeroDatabaseHandler.PutHero(h);
            
        }
        
        [HttpDelete]
        public void Delete([FromBody]int HID)
        {
            HeroDatabaseHandler.DeleteHero(HID);
            
        }
        
    }



    }

