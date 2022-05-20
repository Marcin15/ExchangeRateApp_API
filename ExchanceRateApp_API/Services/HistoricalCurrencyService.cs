using ExchanceRateApp_API.Dtos;
using ExchanceRateApp_API.Helpers;
using ExchanceRateApp_API.Interfaces;
using ExchanceRateApp_API.Models;

namespace ExchanceRateApp_API.Services
{
    public class HistoricalCurrencyService : IHistoricalCurrencyService
    {
        private readonly IOuterWebApiDataReceiveService _outerWebApiDataReceiveService;

        public HistoricalCurrencyService(IOuterWebApiDataReceiveService outerWebApiDataReceiveService)
        {
            _outerWebApiDataReceiveService = outerWebApiDataReceiveService;
        }

        public List<HistoricalCurrencyModel> GetHistoricalCurrencyData(string baseCurrency, string exchangeCurrency, DateTime startDate, DateTime endDate)
        {
            List<HistoricalCurrencyModel> currencyModels = new();

            var data = Deserializer.Deserialize<HistoricalCurrencyDto>(_outerWebApiDataReceiveService.GetHistoricalCurrencyRates(baseCurrency, exchangeCurrency, startDate, endDate).Result);
            var symbols = GetSymbolsFromData(data);

            foreach (var symbol in symbols)
            {
                Dictionary<DateTime, float> date_currencyValueDic = new();
                foreach (var date_symbolCurrencyDic in data.Rates)
                {
                    foreach (var symbol_currency in date_symbolCurrencyDic.Value)
                    {
                        if(symbol_currency.Key == symbol)
                        {
                            date_currencyValueDic.Add(date_symbolCurrencyDic.Key, symbol_currency.Value);
                        }
                    }
                }

                currencyModels.Add(new HistoricalCurrencyModel
                {
                    Symbol = symbol,
                    Rates = date_currencyValueDic
                });
            }

            return currencyModels;
        }

        private List<string> GetSymbolsFromData(HistoricalCurrencyDto data)
        {
            List<string> symbols = new();
            foreach (var rates in data.Rates.Select((val, i) => new { i, val }))
            {
                var symbol_currValueDic = rates.val.Value;
                if (rates.i == 0)
                {
                    foreach (var symbol_currValue in symbol_currValueDic)
                    {
                        symbols.Add(symbol_currValue.Key);
                    }
                }
            }

            return symbols;
        }

    }
}