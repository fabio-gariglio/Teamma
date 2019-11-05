using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core
{
    public class SpikeReport
    {
        public string Title { get; set; }
        public double Estimate { get; set; }
    }

    public interface ISpikeReporter
    {
        Task<IEnumerable<SpikeReport>> GetSpikesBySprintId(int sprintId);
    }
}
