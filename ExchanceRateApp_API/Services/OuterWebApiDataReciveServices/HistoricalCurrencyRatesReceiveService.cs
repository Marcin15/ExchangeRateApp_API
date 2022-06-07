using ExchangeRateApp_API.Interfaces;
using ExchangeRateApp_API.Queries;

namespace ExchangeRateApp_API.Services
{
    public class HistoricalCurrencyRatesReceiveService : ICurrencyRatesService<HistoricalCurrencyQuery>
    {
        private readonly IHttpClientManager _httpClientManager;
        private readonly IStringArrayToStringMapService _stringArrayToStringMapService;
        private readonly IConfiguration _configuration;

        public HistoricalCurrencyRatesReceiveService() { }

        public HistoricalCurrencyRatesReceiveService(IHttpClientManager httpClientManager,
                                                     IStringArrayToStringMapService stringArrayToStringMapService,
                                                     IConfiguration configuration)
        {
            _httpClientManager = httpClientManager;
            _stringArrayToStringMapService = stringArrayToStringMapService;
            _configuration = configuration;
        }

        public async Task<string> ReceiveJsonAsync(HistoricalCurrencyQuery historicalCurrencyQuery)
        {
            var client = _httpClientManager.GetHttpCliet(_configuration["BaseUrl"]);

            var startDate = historicalCurrencyQuery.StartDate.ToString("yyyy-MM-dd");
            var endDate = historicalCurrencyQuery.EndDate.ToString("yyyy-MM-dd");
            var baseCurrency = historicalCurrencyQuery.BaseCurrency.ToUpper();
            var exchangeCurrency = _stringArrayToStringMapService.MapExchangeCurrencyArraytoString(historicalCurrencyQuery.ExchangeCurrency);

            HttpResponseMessage response = await client.GetAsync($"timeseries?start_date={startDate}&end_date={endDate}&base={baseCurrency}&symbols={exchangeCurrency}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
