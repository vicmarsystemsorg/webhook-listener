namespace Webhook.Listener.API.DTOS.UpdateBranchProtection
{
    public class BypassPullRequestAllowances
    {
        public string[] users { get; set; }
        public string[] teams { get; set; }
    }
}
