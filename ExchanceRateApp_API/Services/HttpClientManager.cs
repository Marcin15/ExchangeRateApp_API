using ExchangeRateApp_API.Interfaces;

namespace ExchangeRateApp_API.Services
{
    public class HttpClientManager : IHttpClientManager
    {
        public HttpClient GetHttpCliet(string baseUrl)
        {
            HttpClient client = new();

            client.BaseAddress = new Uri(baseUrl);

            return client;
        }
    }
}
