using System.Text;
using System.Text.Json;
using Webhook.Listener.API.DTOS;
using Webhook.Listener.API.DTOS.Repository;
using Webhook.Listener.API.DTOS.UpdateBranchProtection;
using Webhook.Listener.API.Github.ApiService.Module.Fabric;

namespace Webhook.Listener.API.Github.ApiService.Module.Services
{
    public class RepositoryService
    {
        public void CreateRepository(string repositoryName)
        {
            var httpClient = HttpClientFabric.GetHttpClient();

            CreateRepositoryDTO createRepoDTO = GetCreateRepositoryDTO(repositoryName);

            var json = JsonSerializer.Serialize(createRepoDTO);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = httpClient.PostAsync("https://api.github.com/orgs/vicmarsystemsorg/repos", data).Result;
            HttpContent content = response.Content;
        }

        public void SetProtectionRules(RepositoryDTO repositoryDTO)
        {
            var httpClient = HttpClientFabric.GetHttpClient();

            var updateBranchProtectionDTO = GetUpdateBranchProtectionDTO();

            var json = JsonSerializer.Serialize(updateBranchProtectionDTO);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var uriEndpoint = $"{repositoryDTO.repository.url}/branches/{repositoryDTO.repository.default_branch}/protection";

            HttpResponseMessage response = httpClient.PutAsync($"{uriEndpoint}", data).Result;
            HttpContent content = response.Content;
        }

        private CreateRepositoryDTO GetCreateRepositoryDTO(string repositoryName)
        {
            var createRepoDTO = new CreateRepositoryDTO
            {
                accept = "application/vnd.github.v3+json",
                name = repositoryName,
                description = $"Repository {repositoryName}",
                Private = false,
                visibility = "public",
                homepage = "https://github.com",
                has_issues = true,
                has_projects = true,
                has_wiki = true,
                is_template = false,
                auto_init = true, //Pass true to create an initial commit with empty README.
                allow_squash_merge = true,
                allow_merge_commit = true,
                allow_rebase_merge = true,
                allow_auto_merge = false,
                delete_branch_on_merge = false
            };

            return createRepoDTO;
        }

        private UpdateBranchProtectionDTO GetUpdateBranchProtectionDTO()
        {
            var updateBranchProtectionDTO = new UpdateBranchProtectionDTO
            {
                accept = "application/vnd.github.v3+json",
                enforce_admins = true,
                required_status_checks = GetRequiredStatusChecks(),
                required_pull_request_reviews = GetRequiredPullRequestsReviews(),
                restrictions = GetRestrictions()
            };

            return updateBranchProtectionDTO;
        }

        private RequiredStatusChecks GetRequiredStatusChecks()
        {
            var requiredStatusChecks = new RequiredStatusChecks
            {
                strict = true,
                contexts = new string[1] { "continuous-integration" }
            };

            return requiredStatusChecks;
        }

        private RequiredPullRequestsReviews GetRequiredPullRequestsReviews()
        {
            var requiredPullRequestsReviews = new RequiredPullRequestsReviews
            {
                dismissal_restrictions = GetDismissalRestrictions(),
                bypass_pull_request_allowances = GetBypassPullRequestAllowances(),
                dismiss_stale_reviews = false,
                require_code_owner_reviews = true,
                required_approving_review_count = 3
            };

            return requiredPullRequestsReviews;
        }

        private BypassPullRequestAllowances GetBypassPullRequestAllowances()
        {
            return new BypassPullRequestAllowances { users = new string[0], teams = new string[0] };
        }

        private DismissalRestrictions GetDismissalRestrictions()
        {
            return new DismissalRestrictions { users = new string[0], teams = new string[0] };
        }

        private Restrictions GetRestrictions()
        {
            var restrictions = new Restrictions
            {
                users = new string[1] { "vicmarsystems" },
                teams = new string[1] { "avengers" }
            };

            return restrictions;
        }
    }
}
