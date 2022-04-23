using Webhook.Listener.API.Github.ApiService.Module.Fabric;

namespace Webhook.Listener.API.Github.ApiService.Module.Services
{
    public class TestAPIService
    {
        public void TestAPIInteraction()
        {
            var httpClient = HttpClientFabric.GetHttpClient();

            HttpResponseMessage response = httpClient.GetAsync("https://api.github.com/orgs/vicmarsystemsorg/hooks").Result;
            HttpContent content = response.Content;
        }
    }
}
