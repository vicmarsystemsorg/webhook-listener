using System.Text;
using System.Text.Json;
using Webhook.Listener.API.DTOS;
using Webhook.Listener.API.Github.ApiService.Module.Fabric;

namespace Webhook.Listener.API.Github.ApiService.Module.Services
{
    public class WebHookService
    {
        public void CreateWebHookCreateRepoEvent()
        {
            var httpClient = HttpClientFabric.GetHttpClient();

            CreateHookDTO createHookDTO = GetNewCreateHookDTO();

            var json = JsonSerializer.Serialize(createHookDTO);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = httpClient.PostAsync("https://api.github.com/orgs/vicmarsystemsorg/hooks", data).Result;
            HttpContent content = response.Content;
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
