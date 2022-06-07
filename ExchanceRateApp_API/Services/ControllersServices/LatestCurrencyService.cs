using ExchangeRateApp_API.Interfaces;
using ExchangeRateApp_API.Helpers;
using ExchangeRateApp_API.Dtos;
using ExchangeRateApp_API.Queries;

namespace ExchangeRateApp_API.Services
{
    public class LatestCurrencyService : ILatestCurrencyService
    {
        private readonly IOuterWebApiDataReciveCreator<LatestCurrencyQuery> _serviceCreator;

        public LatestCurrencyService(IOuterWebApiDataReciveCreator<LatestCurrencyQuery> serviceCreator)
        {
            _serviceCreator = serviceCreator;
        }

        public async Task<LatestCurrencyDtos> GetLatestCurrencyAsync(LatestCurrencyQuery latestCurrencyRequestDto)
        {
            return Deserializer
                .Deserialize<LatestCurrencyDtos>(await _serviceCreator
                .GetService(latestCurrencyRequestDto)
                .ReceiveJsonAsync(latestCurrencyRequestDto));
        }
    }
}
