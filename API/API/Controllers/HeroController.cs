
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
    public class HeroController : ControllerBase
    {
        private readonly ILogger<HeroController> _logger;

        public HeroController(ILogger<HeroController> logger)
        {
            _logger = logger;
        }
        [EnableCors("MyPolicy")]
        [HttpGet]
        public IEnumerable<Hero> Get()
        {
          return HeroDatabaseHandler.GetHero();
        }
        [EnableCors("MyPolicy")]
        [HttpGet]
        [Route("/Hero/{HID}")]
        public Hero GetHero(int HID)
        {
            return HeroDatabaseHandler.GetIDHero(HID);
        }
        [EnableCors("MyPolicy")]
        [HttpPost]
        public void Post([FromBody]Hero h)
        {
            HeroDatabaseHandler.PostHero(h);
        }
        [EnableCors("MyPolicy")]
        [HttpPut]
        public void Put([FromBody]Hero h)
        {
            HeroDatabaseHandler.PutHero(h);
            
        }
        [EnableCors("MyPolicy")]
        [HttpDelete("{hid}")]
        public void Delete(int hid)
        {
            System.Console.WriteLine("Deleting Hero with ID: " + hid);
            HeroDatabaseHandler.DeleteHero(hid);
            
        }
        
    }



    }

