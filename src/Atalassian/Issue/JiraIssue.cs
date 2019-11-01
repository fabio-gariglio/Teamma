namespace Atalassian.Issue
{
    public class JiraIssue
    {
        public string Key { get; set; }
        public JiraChangelog Changelog { get; set; } = new JiraChangelog();
    }
}
