using ExchangeRateApp_API.Queries;

namespace ExchangeRateApp_API.Interfaces
{
    public interface ILatestCurrencyRatesReceiveService
    {
        Task<string> ReceiveJsonAsync(LatestCurrencyQuery latestCurrencyQuery);
    }
}