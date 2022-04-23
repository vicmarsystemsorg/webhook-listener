using Microsoft.AspNetCore.Mvc;
using Webhook.Listener.API.Github.ApiService.Module.Services;

namespace Webhook.Listener.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitHubApiInteractionController : ControllerBase
    {
        private readonly RepositoryService _repositoryService;
        private readonly WebHookService _webhookService;
        private readonly TestAPIService _testAPIService;

        public GitHubApiInteractionController()
        {
            _repositoryService = new RepositoryService();
            _webhookService = new WebHookService();
            _testAPIService = new TestAPIService();
        }

        [HttpGet("CreateWebHookCreateRepoEvent")]
        public IActionResult CreateWebHookCreateRepoEvent()
        {
            _webhookService.CreateWebHookCreateRepoEvent();

            return new OkResult();
        }

        [HttpGet("TestingAPIInteraction")]
        public IActionResult TestingAPIInteraction()
        {
            _testAPIService.TestAPIInteraction();

            return new OkResult();
        }

        [HttpGet("CreateRepository")]
        public IActionResult CreateRepository(string repositoryName)
        {
            _repositoryService.CreateRepository(repositoryName);

            return new OkResult();
        }
    }
}
