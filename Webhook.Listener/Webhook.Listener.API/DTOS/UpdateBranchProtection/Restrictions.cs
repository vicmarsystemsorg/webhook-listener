namespace Webhook.Listener.API.DTOS.UpdateBranchProtection
{
    public class Restrictions
    {
        public string[] users { get; set; }
        public string[] teams { get; set; }
    }
}
