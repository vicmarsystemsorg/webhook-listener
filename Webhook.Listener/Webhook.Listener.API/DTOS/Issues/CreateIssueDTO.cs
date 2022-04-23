namespace Webhook.Listener.API.DTOS.Issues
{
    public class CreateIssueDTO
    {
        public string accept { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public string[] assignees { get; set; }
    }
}
