using ExchangeRateApp_API.Interfaces;
using ExchangeRateApp_API.Helpers;
using ExchangeRateApp_API.Dtos;
using ExchangeRateApp_API.Queries;

namespace ExchangeRateApp_API.Services
{
    public class LatestCurrencyService : ILatestCurrencyService
    {
        private readonly IOuterWebApiDataReceiveService _outerWebApiDataReceiveService;

        public LatestCurrencyService(IOuterWebApiDataReceiveService outerWebApiDataReceiveService)
        {
            _outerWebApiDataReceiveService = outerWebApiDataReceiveService;
        }

        public LatestCurrencyDtos GetLatestCurrency(LatestCurrencyQuery latestCurrencyRequestDto) =>
               Deserializer.Deserialize<LatestCurrencyDtos>(_outerWebApiDataReceiveService.GetLatestCurrencyRates(latestCurrencyRequestDto).Result);
    }
}
