using ExchangeRateApp_API.Interfaces;
using ExchangeRateApp_API.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateApp_API.Services
{
    public class LatestCurrencyRatesReceiveService : ICurrencyRatesService<LatestCurrencyQuery>
    {
        private readonly IHttpClientManager _httpClientManager;
        private readonly IStringArrayToStringMapService _stringArrayToStringMapService;
        private readonly IConfiguration _configuration;

        public LatestCurrencyRatesReceiveService(IHttpClientManager httpClientManager,
                                                 IStringArrayToStringMapService stringArrayToStringMapService,
                                                 IConfiguration configuration)
        {
            _httpClientManager = httpClientManager;
            _stringArrayToStringMapService = stringArrayToStringMapService;
            _configuration = configuration;
        }

        public async Task<string> ReceiveJsonAsync(LatestCurrencyQuery latestCurrencyQuery)
        {
            var client = _httpClientManager.GetHttpCliet(_configuration["BaseUrl"]);

            var baseCurrency = latestCurrencyQuery.BaseCurrrency.ToUpper();
            var exchanceCurrency = _stringArrayToStringMapService.MapExchangeCurrencyArraytoString(latestCurrencyQuery.ExchanceCurrency);

            HttpResponseMessage response = await client.GetAsync($"latest?base={baseCurrency}&symbols={exchanceCurrency}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
