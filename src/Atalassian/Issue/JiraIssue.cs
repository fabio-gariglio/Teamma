namespace Atalassian.Issue
{
    public class JiraIssue
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public JiraChangelog Changelog { get; set; } = new JiraChangelog();
    }
}
