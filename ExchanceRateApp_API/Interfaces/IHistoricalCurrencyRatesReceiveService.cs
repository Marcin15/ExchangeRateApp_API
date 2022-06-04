using ExchangeRateApp_API.Queries;

namespace ExchangeRateApp_API.Interfaces
{
    public interface IHistoricalCurrencyRatesReceiveService
    {
        Task<string> ReceiveJsonAsync(HistoricalCurrencyQuery historicalCurrencyQuery);
    }
}