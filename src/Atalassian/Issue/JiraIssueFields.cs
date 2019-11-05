using System.Collections.Generic;
using System.Linq;

namespace Atalassian.Issue
{
    public class JiraIssueFields
    {
        public string Summary { get; set; }
        public JiraIssueType IssueType { get; set; } = new JiraIssueType();
        public IEnumerable<JiraComponent> Components { get; set; } = Enumerable.Empty<JiraComponent>();
        public JiraEpic Epic { get; set; } = new JiraEpic();
    }
}