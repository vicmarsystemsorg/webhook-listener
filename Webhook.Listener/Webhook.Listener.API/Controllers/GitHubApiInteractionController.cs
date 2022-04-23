using Microsoft.AspNetCore.Mvc;
using Octokit;
using System.Text;
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
            var connection = GetConnection();

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
                events = new string[1] {"repository"}
            };

            var data = connection.Post(new Uri("https://api.github.com/orgs/vicmarsystemsorg/hooks"),
                createHookDTO,
                "application/json").Result;

            return new OkResult();
        }

        [HttpGet("TestingAPIInteraction")]
        public IActionResult TestingAPIInteraction()
        {
            //var connection = GetConnection();
            //var data = connection.Get<HttpResponse>(new Uri("https://api.github.com/orgs/vicmarsystemsorg/hooks"), TimeSpan.FromSeconds(20)).Result;

            var httpClient = new HttpClient();
            //var byteArray = Encoding.ASCII.GetBytes("vicmarsystems:");
            //httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            httpClient.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("vicmarsystemsorg", "1.0"));
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Token", "");

            HttpResponseMessage response = httpClient.GetAsync("https://api.github.com/orgs/vicmarsystemsorg/hooks").Result;
            HttpContent content = response.Content;

            return new OkObjectResult(content);
        }

        private IConnection GetConnection()
        {
            var tokenAuth = new Credentials("");

            var client = new GitHubClient(new ProductHeaderValue("vicmarsystemsorg"));
            client.Credentials = tokenAuth;

            //var data = await client.Repository.GetAllForCurrent();

            return client.Connection;
        }
    }
}
