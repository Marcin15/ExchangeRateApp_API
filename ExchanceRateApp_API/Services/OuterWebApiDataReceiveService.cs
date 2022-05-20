using ExchanceRateApp_API.Interfaces;

namespace ExchanceRateApp_API.Services
{
    public class OuterWebApiDataReceiveService : IOuterWebApiDataReceiveService
    {
        private const string baseUrl = "https://api.exchangerate.host/";

        private readonly IHttpClientManager _httpClientManager;

        public OuterWebApiDataReceiveService(IHttpClientManager httpClientManager)
        {
            _httpClientManager = httpClientManager;
        }

        public async Task<string> GetHistoricalCurrencyRates(string baseCurrency, string exchanceCurrency, DateTime startDate, DateTime endDate)
        {
            var client = _httpClientManager.GetHttpCliet(baseUrl);

            HttpResponseMessage response = await client.GetAsync($"timeseries?start_date={startDate:yyyy-MM-dd}&end_date={endDate:yyyy-MM-dd}&base={baseCurrency.ToUpper()}&symbols={exchanceCurrency.ToUpper()}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetLatestCurrencyRates(string baseCurrency, string exchanceCurrency)
        {
            var client = _httpClientManager.GetHttpCliet(baseUrl);

            HttpResponseMessage response = await client.GetAsync($"latest?base={baseCurrency.ToUpper()}&symbols={exchanceCurrency.ToUpper()}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
