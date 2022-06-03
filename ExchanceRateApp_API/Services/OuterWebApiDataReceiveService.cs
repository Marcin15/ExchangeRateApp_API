using ExchangeRateApp_API.Interfaces;
using ExchangeRateApp_API.Queries;
using System.Globalization;

namespace ExchangeRateApp_API.Services
{
    public class OuterWebApiDataReceiveService : IOuterWebApiDataReceiveService
    {
        private const string baseUrl = "https://api.exchangerate.host/";

        private readonly IHttpClientManager _httpClientManager;
        private readonly IStringArrayToStringMapService _stringArrayToStringMapService;

        public OuterWebApiDataReceiveService(IHttpClientManager httpClientManager, 
                                             IStringArrayToStringMapService stringArrayToStringMapService)
        {
            _httpClientManager = httpClientManager;
            _stringArrayToStringMapService = stringArrayToStringMapService;
        }

        public async Task<string> GetHistoricalCurrencyRates(HistoricalCurrencyQuery historicalCurrencyRequestDto)
        {
            var client = _httpClientManager.GetHttpCliet(baseUrl);
            
            var startDate = historicalCurrencyRequestDto.StartDate.ToString("yyyy-MM-dd");
            var endDate = historicalCurrencyRequestDto.EndDate.ToString("yyyy-MM-dd");
            var baseCurrency = historicalCurrencyRequestDto.BaseCurrency.ToUpper();
            var exchangeCurrency = _stringArrayToStringMapService.MapExchangeCurrencyArraytoString(historicalCurrencyRequestDto.ExchangeCurrency);

            HttpResponseMessage response = await client.GetAsync($"timeseries?start_date={startDate}&end_date={endDate}&base={baseCurrency}&symbols={exchangeCurrency}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetLatestCurrencyRates(LatestCurrencyQuery latestCurrencyRequestDto)
        {
            var client = _httpClientManager.GetHttpCliet(baseUrl);

            var baseCurrency = latestCurrencyRequestDto.BaseCurrrency.ToUpper();
            var exchanceCurrency = _stringArrayToStringMapService.MapExchangeCurrencyArraytoString(latestCurrencyRequestDto.ExchanceCurrency);

            HttpResponseMessage response = await client.GetAsync($"latest?base={baseCurrency}&symbols={exchanceCurrency}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
