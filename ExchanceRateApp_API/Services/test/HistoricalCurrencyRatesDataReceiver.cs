using ExchangeRateApp_API.Interfaces;
using ExchangeRateApp_API.Queries;

namespace ExchangeRateApp_API.Services
{
    public class HistoricalCurrencyRatesDataReceiver : IDataReceiver
    {
        private readonly IHttpClientManager _httpClientManager;
        private readonly IStringArrayToStringMapService _stringArrayToStringMapService;
        public HistoricalCurrencyRatesDataReceiver(IHttpClientManager httpClientManager, 
                                                   IStringArrayToStringMapService stringArrayToStringMapService)
        {
            _httpClientManager = httpClientManager;
            _stringArrayToStringMapService = stringArrayToStringMapService;
        }

        public async Task<string> ReceiveDataAsync(string baseUrl, object query)
        {
            var client = _httpClientManager.GetHttpCliet(baseUrl);

            var historicalCurrencyQuery = query as HistoricalCurrencyQuery;

            var startDate = historicalCurrencyQuery.StartDate.ToString("yyyy-MMM-dd");
            var endDate = historicalCurrencyQuery.EndDate.ToString("yyyy-MM-dd");
            var baseCurrency = historicalCurrencyQuery.BaseCurrency.ToUpper();
            var exchangeCurrency = _stringArrayToStringMapService.MapExchangeCurrencyArraytoString(historicalCurrencyQuery.ExchangeCurrency);

            HttpResponseMessage response = await client.GetAsync($"timeseries?start_date={startDate}&end_date={endDate}&base={baseCurrency}&symbols={exchangeCurrency}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
