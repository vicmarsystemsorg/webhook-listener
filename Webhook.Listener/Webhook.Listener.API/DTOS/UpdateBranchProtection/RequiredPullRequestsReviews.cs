namespace Webhook.Listener.API.DTOS.UpdateBranchProtection
{
    public class RequiredPullRequestsReviews
    {
        public DismissalRestrictions dismissal_restrictions { get; set; }
        public bool dismiss_stale_reviews { get; set; }
        public bool require_code_owner_reviews { get; set; }
        public int required_approving_review_count { get; set; }
        public BypassPullRequestAllowances bypass_pull_request_allowances { get; set; }
    }
}
