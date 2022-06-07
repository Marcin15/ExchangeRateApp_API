using ExchangeRateApp_API.Entities;
using ExchangeRateApp_API.Exceptions;
using ExchangeRateApp_API.Interfaces;
using Newtonsoft.Json;

namespace ExchangeRateApp_API.Services
{
    public class CurrencySymbolsFileReadService : ICurrencySymbolsFileReadService
    {
        private readonly IConfiguration _configuration;

        public CurrencySymbolsFileReadService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public FileCurrencySymbol ReadSymbols()
        {
            var readJson = File.ReadAllText(_configuration["CurrencySymbolsFilePath"]);
            var currencySymbolsEntity = JsonConvert.DeserializeObject<FileCurrencySymbol>(readJson);

            return currencySymbolsEntity;
        }
    }
}
