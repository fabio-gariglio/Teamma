using System.Net.Http;
using System.Threading.Tasks;
using Atalassian.Issue;
using Core;
using Newtonsoft.Json;

namespace Atalassian.Sprint
{
    public class SprintRepository : ISprintRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper<JiraSprint, JiraIssueCollection, Core.Sprint> _mapper;

        public SprintRepository(IHttpClientFactory httpClientFactory, IMapper<JiraSprint, JiraIssueCollection, Core.Sprint> mapper)
        {
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
        }

        public async Task<Core.Sprint> GetById(int sprintId)
        {
            var jiraSprint = await GetSprintById(sprintId);
            var jiraIssueCollection = await GetSprintIssueCollectionById(sprintId);

            var sprint = _mapper.Map(jiraSprint, jiraIssueCollection);

            return sprint;
        }

        private async Task<JiraSprint> GetSprintById(int sprintId)
        {
            using (var client = _httpClientFactory.CreateClient("jiraClient"))
            {
                var payload = await client.GetStringAsync($"/rest/agile/latest/sprint/{sprintId}");
                var jiraSprint = JsonConvert.DeserializeObject<JiraSprint>(payload);

                return jiraSprint;
            }
        }

        private async Task<JiraIssueCollection> GetSprintIssueCollectionById(int sprintId)
        {
            using (var client = _httpClientFactory.CreateClient("jiraClient"))
            {
                var payload = await client.GetStringAsync($"/rest/agile/latest/sprint/{sprintId}/issue?fields=summary,issuetype,components,epic&expand=changelog");
                var jiraIssueCollection = JsonConvert.DeserializeObject<JiraIssueCollection>(payload);

                return jiraIssueCollection;
            }
        }
    }
}
