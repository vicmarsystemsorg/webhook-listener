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
            var tokenAuth = new Credentials("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");

            var client = new GitHubClient(new ProductHeaderValue("vicmarsystemsorg"));
            client.Credentials = tokenAuth;

            var data = await client.Repository.GetAllForCurrent();

            return new OkObjectResult(data);
        }
    }
}
