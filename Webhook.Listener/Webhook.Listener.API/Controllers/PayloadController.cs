using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Webhook.Listener.API.DTOS.Repository;
using Webhook.Listener.API.Github.ApiService.Module.Services;

namespace Webhook.Listener.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PayloadController : ControllerBase
    {
        private readonly RepositoryService _repositoryService;
        private readonly IssuesService _issuesService;

        public PayloadController()
        {
            _repositoryService = new RepositoryService();
            _issuesService = new IssuesService();
        }

        [HttpPost]
        public IActionResult Payload([FromBody] JsonElement payload)
        {
            var repositoryDTO = JsonSerializer.Deserialize<RepositoryDTO>(payload);

            if (repositoryDTO?.action != "created")
                return new OkResult();

            _repositoryService.SetProtectionRules(repositoryDTO);

            _issuesService.CreateIssue(repositoryDTO);

            return new OkResult();
        }
    }
}
