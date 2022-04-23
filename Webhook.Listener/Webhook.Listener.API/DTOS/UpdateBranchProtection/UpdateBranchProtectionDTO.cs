namespace Webhook.Listener.API.DTOS.UpdateBranchProtection
{
    public class UpdateBranchProtectionDTO
    {
        public string accept { get; set; }
        public RequiredStatusChecks required_status_checks { get; set; }
        public bool enforce_admins { get; set; }
        public RequiredPullRequestsReviews required_pull_request_reviews { get; set; }
        public Restrictions restrictions { get; set; }
    }
}
