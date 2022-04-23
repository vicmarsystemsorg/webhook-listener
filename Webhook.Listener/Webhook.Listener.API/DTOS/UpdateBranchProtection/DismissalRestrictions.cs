namespace Webhook.Listener.API.DTOS.UpdateBranchProtection
{
    public class DismissalRestrictions
    {
        public string[] users { get; set; }
        public string[] teams { get; set; }
    }
}
