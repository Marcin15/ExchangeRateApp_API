using Application.Dto;
using Application.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CurrencyGetterService : ICurrencyGetterService
    {
        private readonly IOuterWebApiDataReceiverService _innerWebApiDataReceiverService;
        public CurrencyGetterService(IOuterWebApiDataReceiverService innerWebApiDataReceiverService)
        {
            _innerWebApiDataReceiverService = innerWebApiDataReceiverService;
        }
        public CurrencyHistoricalDateDto GetCurrency()
        {
            string json = _innerWebApiDataReceiverService.GetResponseFromOuterWebAPI().Result;

            CurrencyHistoricalDateDto currencyDto = JsonConvert.DeserializeObject<CurrencyHistoricalDateDto>(json);

            return currencyDto;
        }
    }
}
