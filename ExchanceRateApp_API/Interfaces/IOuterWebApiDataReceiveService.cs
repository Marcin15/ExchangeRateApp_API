using ExchangeRateApp_API.Queries;

namespace ExchangeRateApp_API.Interfaces
{
    public interface IOuterWebApiDataReceiveService
    {
        Task<string> GetHistoricalCurrencyRates(HistoricalCurrencyQuery historicalCurrencyRequestDto);
        Task<string> GetLatestCurrencyRates(LatestCurrencyQuery latestCurrencyRequestDto);
    }
}