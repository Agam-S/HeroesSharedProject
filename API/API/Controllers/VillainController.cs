// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Logging;

// namespace API.Controllers
// {
//     [ApiController]
//     [Route("[controller]")]
//     public class VillainController : ControllerBase
//     {
//         static List<Villain> villianList = new List<Villain>() {
        
//         new Villain(1, "Mark Zukerburg", 5),
//         new Villain(2, "Mr James", 10),
//         new Villain(3, "NEIN", 9)
        
//         };


//         [HttpGet]
//         public IEnumerable<Villain> Get()
//         {
//           return villianList;
//         }

//         // [HttpPut]
//         // public List<Villain> Put() {


//         // }
//         }

//     }
// }
