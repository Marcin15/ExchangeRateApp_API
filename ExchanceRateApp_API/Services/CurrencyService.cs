using ExchanceRateApp_API.Dtos;
using ExchanceRateApp_API.Interfaces;
using ExchanceRateApp_API.Models;
using System.Diagnostics;

namespace ExchanceRateApp_API.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrencyGetterService _currencyGetterService;

        public CurrencyService(ICurrencyGetterService currencyGetterService)
        {
            _currencyGetterService = currencyGetterService;
        }

        public List<CurrencyModel> GetCurrencyData()
        {
            var data = _currencyGetterService.GetRawCurrencyData();
            List<CurrencyModel> currencyModels = new();
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

                currencyModels.Add(new CurrencyModel
                {
                    Symbol = symbol,
                    CurrencyValue = date_currencyValueDic
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

//currencyModels.Add(new CurrencyModel
//{
//    Symbol = currency.Key,
//    //CurrencyValue = new Dictionary<DateTime, float>
//    //{
//    //    { rate.Key, 12f }
//    //}
//});