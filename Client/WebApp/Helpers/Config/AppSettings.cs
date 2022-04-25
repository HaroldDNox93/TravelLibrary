namespace WebApp.Helpers.Config
{
    public class AppSettings
    {
        private static AppSettings settings;
        public static AppSettings Settings { get => settings; set => settings = value; }
        public string ApiKey { get; set; }
        public IntegrationApi IntegrationApi { get; set; }
    }
}
