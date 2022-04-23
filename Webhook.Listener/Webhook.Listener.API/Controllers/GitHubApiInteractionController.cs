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
    }
}
