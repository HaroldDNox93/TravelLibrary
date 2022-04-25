using System.Collections.Generic;

namespace WebApp.Helpers.Config
{
    public class IntegrationApi
    {
        public List<ServicesSettings> Services { get; set; }
    }

    public class ServicesSettings
    {
        public string Name { get; set; }
        public string URL { get; set; }
        public List<Methods>Methods { get; set; }
    }

    public class Methods
    {
        public string Method { get; set; }
        public string Value { get; set; }
    }
}
