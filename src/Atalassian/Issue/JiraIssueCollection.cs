using System.Collections.Generic;
using System.Linq;

namespace Atalassian.Issue
{
    public class JiraIssueCollection
    {
        public IEnumerable<JiraIssue> Issues { get; set; } = Enumerable.Empty<JiraIssue>();
    }
}