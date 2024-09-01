using Microsoft.Extensions.Configuration;

namespace Core.Config.Configs
{
    public class SmsConfig
    {
        public void LoadSettings(IConfiguration configuration)
        {
            Url = configuration["Url"];
            ApiKey = configuration["ApiKey"];
            SecretKey = configuration["SecretKey"];
            SmsType = configuration["SmsType"];
            BrandName = configuration["BrandName"];
            IsSend = bool.TryParse(configuration["IsSend"], out var isSend) && isSend;
        }

        public string Url { get; set; }
        public bool IsSend { get; set; }
        public string ApiKey { get; set; }
        public string SecretKey { get; set; }
        public string SmsType { get; set; }
        public string BrandName { get; set; }
    }
}