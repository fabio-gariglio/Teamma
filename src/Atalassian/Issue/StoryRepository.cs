using System.Net.Http;
using System.Threading.Tasks;
using Core;
using Newtonsoft.Json;

namespace Atalassian.Issue
{
    public class StoryRepository : IStoryRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper<JiraIssue, Story> _mapper;

        public StoryRepository(IHttpClientFactory httpClientFactory, IMapper<JiraIssue, Story> mapper)
        {
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
        }

        public async Task<Story> GetById(int storyInternalId)
        {
            using (var client = _httpClientFactory.CreateClient("jiraClient"))
            {
                var payload = await client.GetStringAsync($"/rest/api/latest/issue/{storyInternalId}?fields=navigable&expand=changelog");
                var issue = JsonConvert.DeserializeObject<JiraIssue>(payload);

                return _mapper.Map(issue);
            }
        }
    }
}
