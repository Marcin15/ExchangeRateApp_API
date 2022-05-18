using ExchanceRateApp_API.Dtos;

namespace ExchanceRateApp_API.Interfaces
{
    public interface ICurrencyGetterService
    {
        HistoricalCurrencyDto GetRawCurrencyData();
    }
}