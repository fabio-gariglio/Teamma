using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    [Route("/")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IRepository<string, int> _counters;

        public MainController(IRepository<string, int> _counters)
        {
            this._counters = _counters;
        }
        
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<object>> Get()
        {
            var visits = await _counters.Get("visits");
            
            visits++;

            await _counters.Save("visits", visits);
            
            return new
            {
                Counter = visits
            };
        }
    }
}
