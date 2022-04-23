namespace Webhook.Listener.API.DTOS
{
    public class ConfigDTO
    {
        public string url { get; set; }
        public string content_type { get; set; }
        public string secret { get; set; }
        public string insecure_ssl { get; set; }
    }
}
