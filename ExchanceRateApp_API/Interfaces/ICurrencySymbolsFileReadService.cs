using ExchanceRateApp_API.Entities;

namespace ExchanceRateApp_API.Interfaces
{
    public interface ICurrencySymbolsFileReadService
    {
        CurrencySymbolsEntity ReadSymbols();
    }
}