using Microsoft.AspNetCore.Mvc;
using Octokit;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Webhook.Listener.API.DTOS;

namespace Webhook.Listener.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitHubApiInteractionController : ControllerBase
    {
        [HttpGet("CreateWebHookCreateRepoEvent")]
        public IActionResult CreateWebHookCreateRepoEvent()
        {
            var httpConnection = GetHttpClient();

            CreateHookDTO createHookDTO = GetNewCreateHookDTO();

            var json = JsonSerializer.Serialize(createHookDTO);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = httpConnection.PostAsync("https://api.github.com/orgs/vicmarsystemsorg/hooks", data).Result;
            HttpContent content = response.Content;

            return new OkResult();
        }

        [HttpGet("TestingAPIInteraction")]
        public IActionResult TestingAPIInteraction()
        {
            var httpClient = GetHttpClient();

            HttpResponseMessage response = httpClient.GetAsync("https://api.github.com/orgs/vicmarsystemsorg/hooks").Result;
            HttpContent content = response.Content;

            return new OkObjectResult(content);
        }

        [HttpGet("CreateRepository")]
        public IActionResult CreateRepository(string repositoryName)
        {
            var httpClient = GetHttpClient();

            CreateRepositoryDTO createRepoDTO = GetCreateRepositoryDTO(repositoryName);

            var json = JsonSerializer.Serialize(createRepoDTO);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = httpClient.PostAsync("https://api.github.com/orgs/vicmarsystemsorg/repos", data).Result;
            HttpContent content = response.Content;

            return new OkObjectResult(content);
        }

        private HttpClient GetHttpClient()
        {
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("vicmarsystemsorg", "1.0"));
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Token", "");

            return httpClient;
        }

        private CreateHookDTO GetNewCreateHookDTO()
        {
            var configDto = new ConfigDTO
            {
                content_type = "json",
                url = "",
                secret = "",
                insecure_ssl = "0"
            };

            var createHookDTO = new CreateHookDTO
            {
                name = "web",
                accept = "application/vnd.github.v3+json",
                config = configDto,
                active = true,
                events = new string[1] { "repository" }
            };
            return createHookDTO;
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
    }
}
