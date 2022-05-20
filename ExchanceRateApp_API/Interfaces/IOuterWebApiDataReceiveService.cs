
namespace ExchanceRateApp_API.Interfaces
{
    public interface IOuterWebApiDataReceiveService
    {
        Task<string> GetHistoricalCurrencyRates(string baseCurrency, string exchanceCurrency, DateTime startDate, DateTime endDate);
        Task<string> GetLatestCurrencyRates(string baseCurrency, string exchanceCurrency);
    }
}