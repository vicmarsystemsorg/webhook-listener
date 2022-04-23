namespace Webhook.Listener.API.DTOS
{
    public class CreateHookDTO
    {
        public string accept { get; set; }
        public string name { get; set; }
        public ConfigDTO config { get; set; }
        public string[] events { get; set; }
        public bool active { get; set; }
    }
}
