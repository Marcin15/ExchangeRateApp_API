using ExchangeRateApp_API.Interfaces;
using ExchangeRateApp_API.Helpers;
using ExchangeRateApp_API.Dtos;
using ExchangeRateApp_API.Queries;

namespace ExchangeRateApp_API.Services
{
    public class LatestCurrencyService : ILatestCurrencyService
    {
        private readonly ILatestCurrencyRatesReceiveService _latestCurrencyRatesReceiveService;

        public LatestCurrencyService(ILatestCurrencyRatesReceiveService latestCurrencyRatesReceiveService)
        {
            _latestCurrencyRatesReceiveService = latestCurrencyRatesReceiveService;
        }

        public async Task<LatestCurrencyDtos> GetLatestCurrencyAsync(LatestCurrencyQuery latestCurrencyRequestDto)
        {
            return Deserializer.Deserialize<LatestCurrencyDtos>(await _latestCurrencyRatesReceiveService.ReceiveJsonAsync(latestCurrencyRequestDto));
        }
    }
}
