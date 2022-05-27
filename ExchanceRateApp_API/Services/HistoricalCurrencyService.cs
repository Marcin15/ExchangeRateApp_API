using ExchangeRateApp_API.Dtos;
using ExchangeRateApp_API.Entities;
using ExchangeRateApp_API.Helpers;
using ExchangeRateApp_API.Interfaces;
using ExchangeRateApp_API.Queries;

namespace ExchangeRateApp_API.Services
{
    public class HistoricalCurrencyService : IHistoricalCurrencyService
    {
        private readonly IOuterWebApiDataReceiveService _outerWebApiDataReceiveService;
        private readonly IHistoricalCurrencyDtoToModelMapService _modelMapService;

        public HistoricalCurrencyService(IOuterWebApiDataReceiveService outerWebApiDataReceiveService, 
                                         IHistoricalCurrencyDtoToModelMapService modelMapService)
        {
            _outerWebApiDataReceiveService = outerWebApiDataReceiveService;
            _modelMapService = modelMapService;
        }

        public List<HistoricalCurrencyDtos> GetHistoricalCurrency(HistoricalCurrencyQuery historicalCurrencyRequestDto)
        {
            var dataFromOuterAPI = Deserializer.Deserialize<HistoricalCurrency>(_outerWebApiDataReceiveService.GetHistoricalCurrencyRates(historicalCurrencyRequestDto).Result);

            return _modelMapService.MapResponseToHistoricalCurrencyModel(dataFromOuterAPI);
        }
    }
}