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
//         private readonly ILogger<VillainController> _logger;

//         public VillainController(ILogger<VillainController> logger)
//         {
//             _logger = logger;
//         }

//         [HttpGet]
//         public IEnumerable<VillainController> Get()
//         {
//           return DatabaseHandler.Villain();
//         }
//     }
// }