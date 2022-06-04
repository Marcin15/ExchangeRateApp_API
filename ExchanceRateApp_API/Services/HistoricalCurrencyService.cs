using ExchangeRateApp_API.Dtos;
using ExchangeRateApp_API.Entities;
using ExchangeRateApp_API.Helpers;
using ExchangeRateApp_API.Interfaces;
using ExchangeRateApp_API.Queries;

namespace ExchangeRateApp_API.Services
{
    public class HistoricalCurrencyService : IHistoricalCurrencyService
    {
        private readonly IHistoricalCurrencyRatesReceiveService _historicalCurrencyRatesReceiveService;
        private readonly IHistoricalCurrencyDtoToModelMapService _modelMapService;

        public HistoricalCurrencyService(IHistoricalCurrencyRatesReceiveService historicalCurrencyRatesReceiveService, 
                                         IHistoricalCurrencyDtoToModelMapService modelMapService)
        {
            _historicalCurrencyRatesReceiveService = historicalCurrencyRatesReceiveService;
            _modelMapService = modelMapService;
        }

        public async Task<List<HistoricalCurrencyDtos>> GetHistoricalCurrencyAsync(HistoricalCurrencyQuery historicalCurrencyRequestDto)
        {
            var dataFromOuterAPI = Deserializer.Deserialize<HistoricalCurrency>(await _historicalCurrencyRatesReceiveService.ReceiveJsonAsync(historicalCurrencyRequestDto));

            return _modelMapService.MapResponseToHistoricalCurrencyModel(dataFromOuterAPI);
        }
    }
}