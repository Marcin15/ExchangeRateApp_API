using ExchangeRateApp_API.Dtos;
using ExchangeRateApp_API.Entities;
using ExchangeRateApp_API.Helpers;
using ExchangeRateApp_API.Interfaces;
using ExchangeRateApp_API.Queries;

namespace ExchangeRateApp_API.Services
{
    public class HistoricalCurrencyService : IHistoricalCurrencyService
    {
        private readonly IOuterWebApiDataReciveCreator<HistoricalCurrencyQuery> _serviceCreator;
        private readonly IHistoricalCurrencyDtoToModelMapService _modelMapService;

        public HistoricalCurrencyService(IOuterWebApiDataReciveCreator<HistoricalCurrencyQuery> serviceCreator, 
                                         IHistoricalCurrencyDtoToModelMapService modelMapService)
        {
            _serviceCreator = serviceCreator;
            _modelMapService = modelMapService;
        }

        public async Task<List<HistoricalCurrencyDtos>> GetHistoricalCurrencyAsync(HistoricalCurrencyQuery historicalCurrencyRequestDto)
        {
            var dataFromOuterAPI = Deserializer
                .Deserialize<HistoricalCurrency>(await _serviceCreator
                .GetService(historicalCurrencyRequestDto)
                .ReceiveJsonAsync(historicalCurrencyRequestDto));

            return _modelMapService.MapResponseToHistoricalCurrencyModel(dataFromOuterAPI);
        }
    }
}