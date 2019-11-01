using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atalassian.Issue;
using Core;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    [Route("/")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IRepository<string, int> _counters;

        public MainController(IRepository<string, int> counters, ISprintRepository repository)
        {
            _counters = counters;
            repository.GetById(5259).Wait();
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
