using ExchangeRateApp_API.Dtos;
using ExchangeRateApp_API.Entities;
using ExchangeRateApp_API.Interfaces;

namespace ExchangeRateApp_API.Services
{
    public class HistoricalCurrencyDtoToModelMapService : IHistoricalCurrencyDtoToModelMapService
    { 
        public List<HistoricalCurrencyDtos> MapResponseToHistoricalCurrencyModel(HistoricalCurrency dataFromOuterAPI)
        {
            var currencySymbols = this.GetCurrencySymbolsFromData(dataFromOuterAPI);

            List<HistoricalCurrencyDtos> currencyModels = new();

            foreach (var symbol in currencySymbols)
            {
                Dictionary<DateTime, float> date_currencyValueDic = new();
                foreach (var date_symbolCurrencyDic in dataFromOuterAPI.Rates)
                {
                    foreach (var symbol_currency in date_symbolCurrencyDic.Value)
                    {
                        if (symbol_currency.Key == symbol)
                        {
                            date_currencyValueDic.Add(date_symbolCurrencyDic.Key, symbol_currency.Value);
                        }
                    }
                }

                currencyModels.Add(new HistoricalCurrencyDtos
                {
                    Symbol = symbol,
                    Rates = date_currencyValueDic
                });
            }

            return currencyModels;
        }

        public List<string> GetCurrencySymbolsFromData(HistoricalCurrency data)
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
