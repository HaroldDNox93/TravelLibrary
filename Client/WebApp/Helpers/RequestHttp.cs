using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebApp.Helpers.Config;

namespace WebApp.Helpers
{
    public static class RequestHttp
    {
        private static AppSettings settings { set; get; } = AppSettings.Settings;
        public enum TypeBody { Body, Query }

        public static async Task<T> CallMethod<T>(string service, string action, HttpMethod method)
        {
            var url = GetUrlApi(service, action);

            return await DoRequest<T>(url, method, null);
        }

        public static async Task<T> CallMethod<T>(string service, string action, HttpMethod method, int id)
        {
            var url = GetUrlApi(service, action);

            return await DoRequest<T>($"{url}/{id}", method, null);
        }

        public static async Task<T> CallMethod<T>(string service, string action, HttpMethod method, TypeBody type, object model)
        {
            var url = GetUrlApi(service, action);

            HttpContent content = null;
            switch (type)
            {
                case TypeBody.Query:
                    content = HttpContentHelper.TypeQuery(model, ref url);
                    break;
                case TypeBody.Body:
                    content = HttpContentHelper.TypeBody(model);
                    break;
            }

            return await DoRequest<T>(url, method, content);
        }

        private static string GetUrlApi(string service, string action)
        {
            var API_KEY = settings.ApiKey;
            var _integrationApi = settings.IntegrationApi;
            var _service = _integrationApi.Services
                .FirstOrDefault(s => s.Name.Equals(service));
            var _action = _service.Methods
                .FirstOrDefault(m => m.Method.Equals(action))
                .Value;

            return $"{_service.URL}{_action}";
        }

        private static async Task<T> DoRequest<T>(string url, HttpMethod method, HttpContent content)
        {
            var API_KEY = settings.ApiKey;
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("ApiKey", API_KEY);
                var request = new HttpRequestMessage(method, url);
                if (content != null) request.Content = content;
                using (var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false))
                {
                    string result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(result);
                }
            }
        }
    }
}
