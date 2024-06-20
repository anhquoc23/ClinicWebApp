namespace ClinicWebAPI.Settings
{
    public class CloudinarySetting
    {
        public string CloudName { get; set; }
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }
        public readonly static string PathAvatar = "Clinic/avatar";
        public CloudinarySetting() { }

        public CloudinarySetting(string cloudName, string apiKey, string apiSecret)
        {
            CloudName = cloudName;
            ApiKey = apiKey;
            ApiSecret = apiSecret;
        }
    }
}
