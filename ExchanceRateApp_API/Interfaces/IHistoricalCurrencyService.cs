using ExchanceRateApp_API.Models;

namespace ExchanceRateApp_API.Interfaces
{
    public interface IHistoricalCurrencyService
    {
        List<HistoricalCurrencyModel> GetHistoricalCurrencyData(string baseCurrency, string exchangeCurrency, DateTime startDate, DateTime endDate);
    }
}