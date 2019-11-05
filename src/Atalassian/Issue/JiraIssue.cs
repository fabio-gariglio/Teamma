namespace Atalassian.Issue
{
    public class JiraIssue
    {
        public string Key { get; set; }
        public JiraIssueFields Fields { get; set; } = new JiraIssueFields();
        public JiraChangelog Changelog { get; set; } = new JiraChangelog();
    }
}
