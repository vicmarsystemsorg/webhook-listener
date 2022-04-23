using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Webhook.Listener.API.DTOS.Repository;

namespace Webhook.Listener.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PayloadController : ControllerBase
    {
        [HttpPost]
        public IActionResult Payload([FromBody] JsonElement payload)
        {
            var repositoryDTO = JsonSerializer.Deserialize<RepositoryDTO>(payload);
            return new OkResult();
        }
    }
}
