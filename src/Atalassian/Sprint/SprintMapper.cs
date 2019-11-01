using System.Linq;
using Atalassian.Issue;
using Core;

namespace Atalassian.Sprint
{
    public class SprintMapper : IMapper<JiraSprint, JiraIssueCollection, Core.Sprint>
    {
        public Core.Sprint Map(JiraSprint jiraSprint, JiraIssueCollection jiraIssueCollection)
        {
            return new Core.Sprint
            {
                Name = jiraSprint.Name,
                StartDate = jiraSprint.StartDate,
                EndDate = jiraSprint.EndDate,
                Stories = jiraIssueCollection.Issues.Select(ToStory).ToArray()
            };
        }

        private Story ToStory(JiraIssue source)
        {
            return new Story
            {
                Id = source.Key
            };
        }
    }
}
