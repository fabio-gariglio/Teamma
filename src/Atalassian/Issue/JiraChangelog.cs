using System.Collections.Generic;
using System.Linq;

namespace Atalassian.Issue
{
    public class JiraChangelog
    {
        public IEnumerable<JiraHistory> Histories { get; set; } = Enumerable.Empty<JiraHistory>();
    }
}