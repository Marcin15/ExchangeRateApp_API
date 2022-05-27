using ExchangeRateApp_API.Entities;

namespace ExchangeRateApp_API.Interfaces
{
    public interface ICurrencySymbolsFileReadService
    {
        FileCurrencySymbol ReadSymbols();
    }
}