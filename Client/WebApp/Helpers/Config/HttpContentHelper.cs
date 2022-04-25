using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace WebApp.Helpers.Config
{
    public class HttpContentHelper
    {
        public static HttpContent TypeQuery(object model, ref string url)
        {
            var json = JsonConvert.SerializeObject(model);
            var queryParams = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            url += $"?{string.Join("&", queryParams.Select(i => $"{i.Key}={i.Value}"))}";
            return new FormUrlEncodedContent(queryParams);
        }

        public static HttpContent TypeBody(object model)
        {
            var json = JsonConvert.SerializeObject(model);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
