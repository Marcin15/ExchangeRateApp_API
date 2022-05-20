using ExchanceRateApp_API.Models;
using ExchanceRateApp_API.Interfaces;
using ExchanceRateApp_API.Helpers;

namespace ExchanceRateApp_API.Services
{
    public class LatestCurrencyService : ILatestCurrencyService
    {
        private readonly IOuterWebApiDataReceiveService _outerWebApiDataReceiveService;

        public LatestCurrencyService(IOuterWebApiDataReceiveService outerWebApiDataReceiveService)
        {
            _outerWebApiDataReceiveService = outerWebApiDataReceiveService;
        }

        public LatestCurrencyModel GetLatestCurrency(string baseCurrency, string exchangeCurrency) =>
               Deserializer.Deserialize<LatestCurrencyModel>(_outerWebApiDataReceiveService.GetLatestCurrencyRates(baseCurrency, exchangeCurrency).Result);
    }
}
