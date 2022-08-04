using Microsoft.AspNetCore.Mvc;

namespace MessageAPI.Models
{
    public class KafkaSettings
    {
        public const string Section = "KafkaSettings";

        public string Topic { get; set; }
        public string BoostrapServer { get; set; }
        public string Protocol { get;set; }
        public string Mechanisms { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
