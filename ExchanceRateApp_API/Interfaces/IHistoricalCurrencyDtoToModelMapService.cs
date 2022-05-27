using ExchangeRateApp_API.Dtos;
using ExchangeRateApp_API.Entities;

namespace ExchangeRateApp_API.Interfaces
{
    public interface IHistoricalCurrencyDtoToModelMapService
    {
        List<HistoricalCurrencyDtos> MapResponseToHistoricalCurrencyModel(HistoricalCurrency dataFromOuterAPI);
    }
}