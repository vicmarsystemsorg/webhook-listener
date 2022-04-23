using System.Net.Http.Headers;

namespace Webhook.Listener.API.Github.ApiService.Module.Fabric
{
    public class HttpClientFabric
    {
        public static HttpClient GetHttpClient()
        {
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("vicmarsystemsorg", "1.0"));
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", "");

            return httpClient;
        }
    }
}
