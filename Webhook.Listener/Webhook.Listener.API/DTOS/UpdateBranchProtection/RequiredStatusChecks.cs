namespace Webhook.Listener.API.DTOS.UpdateBranchProtection
{
    public class RequiredStatusChecks
    {
        public bool strict { get; set; }
        public string[] contexts { get; set; }
    }
}
