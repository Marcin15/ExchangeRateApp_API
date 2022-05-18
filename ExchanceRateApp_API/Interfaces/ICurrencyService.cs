using ExchanceRateApp_API.Models;

namespace ExchanceRateApp_API.Interfaces
{
    public interface ICurrencyService
    {
        List<CurrencyModel> GetCurrencyData();
    }
}