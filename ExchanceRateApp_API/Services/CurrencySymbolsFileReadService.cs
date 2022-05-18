using ExchanceRateApp_API.Entities;
using ExchanceRateApp_API.Interfaces;
using Newtonsoft.Json;

namespace ExchanceRateApp_API.Services
{
    public class CurrencySymbolsFileReadService : ICurrencySymbolsFileReadService
    {
        public CurrencySymbolsEntity ReadSymbols()
        {
            CurrencySymbolsEntity currencySymbolsEntity = new();

            var readJson = File.ReadAllText("../Data/ExchanceRateApp/JSONresult.txt");
            currencySymbolsEntity = JsonConvert.DeserializeObject<CurrencySymbolsEntity>(readJson);

            return currencySymbolsEntity;
        }
    }
}
