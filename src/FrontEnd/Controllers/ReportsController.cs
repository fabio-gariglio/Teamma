using System.Collections.Generic;
using System.Threading.Tasks;
using Core;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    [Route("/reports")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly ISpikeReporter _reporter;

        public ReportsController(ISpikeReporter reporter)
        {
            _reporter = reporter;
        }
        
        // GET api/values
        [HttpGet("spikes")]
        public async Task<IEnumerable<SpikeReport>> Get()
        {
            var spikes = await _reporter.GetSpikesBySprintId(5259);

            return spikes;
        }
    }
}
