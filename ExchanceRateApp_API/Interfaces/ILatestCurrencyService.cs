using ExchanceRateApp_API.Models;

namespace ExchanceRateApp_API.Interfaces
{
    public interface ILatestCurrencyService
    {
        LatestCurrencyModel GetLatestCurrency(string baseCurrency, string exchangeCurrency);
    }
}