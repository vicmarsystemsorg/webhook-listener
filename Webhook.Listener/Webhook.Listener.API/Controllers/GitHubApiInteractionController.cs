using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Octokit;

namespace Webhook.Listener.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitHubApiInteractionController : ControllerBase
    {
        [HttpGet("CreateWebHookCreateRepoEvent")]
        public IActionResult CreateWebHookCreateRepoEvent()
        {
            

            return new OkResult();
        }

        [HttpGet("TestingAPIInteraction")]
        public async Task<IActionResult> TestingAPIInteraction()
        {
            var connection = GetConnection();
            var data = await connection.Get<HttpResponse>(new Uri("https://api.github.com/orgs/vicmarsystemsorg/hooks"), TimeSpan.FromSeconds(20));

            return new OkObjectResult(data);
        }

        private IConnection GetConnection()
        {
            var tokenAuth = new Credentials("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");

            var client = new GitHubClient(new ProductHeaderValue("vicmarsystemsorg"));
            client.Credentials = tokenAuth;

            //var data = await client.Repository.GetAllForCurrent();

            return client.Connection;
        }
    }
}
