using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core
{
    public class SpikeReporter : ISpikeReporter
    {
        private static readonly Regex SpikeEstimateRegex = new Regex(@"\[(?<Estimate>[\d\.]+)d?\].*", RegexOptions.Compiled);
        private readonly ISprintRepository _repository;

        public SpikeReporter(ISprintRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<SpikeReport>> GetSpikesBySprintId(int sprintId)
        {
            var sprint = await _repository.GetById(sprintId);
            var spikes = sprint
                .Stories
                .Where(s => s.Type == "Spike")
                .Select(AsSpikeReport)
                .ToArray();

            return spikes;
        }

        private static SpikeReport AsSpikeReport(Story story)
        {
            return new SpikeReport
            {
                Title = story.Title,
                Estimate = GetSpikeEstimate(story)
            };
        }

        private static double GetSpikeEstimate(Story story)
        {
            var match = SpikeEstimateRegex.Match(story.Title);
            var estimate = match.Groups["Estimate"].Value;

            return double.TryParse(estimate, out double result)
                ? result
                : 0;
        }
    }
}