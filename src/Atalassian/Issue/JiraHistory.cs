using System;
using System.Collections.Generic;
using System.Linq;

namespace Atalassian.Issue
{
    public class JiraHistory
    {
        public DateTime Created { get; set; }
        public IEnumerable<JiraHistoryItem> Items { get; set; } = Enumerable.Empty<JiraHistoryItem>();
    }
}