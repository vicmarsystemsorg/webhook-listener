using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Webhook.Listener.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PayloadController : ControllerBase
    {
        [HttpPost]
        public IActionResult Payload([FromBody] JsonElement payload)
        {
            return new OkResult();
        }
    }
}
