namespace Webhook.Listener.API.DTOS.Repository
{
    public class Repository
    {
        public int id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string branches_url { get; set; }
        public string default_branch { get; set; }
    }
}
