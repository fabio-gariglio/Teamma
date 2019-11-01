using Core;

namespace Atalassian.Issue
{
    public class JiraIssueToStoryMapper : IMapper<JiraIssue, Story>
    {
        public Story Map(JiraIssue source)
        {
            return new Story
            {
                InternalId = source.Id,
                Id = source.Key
            };
        }
    }
}
