using ExchanceRateApp_API.Dtos;
using ExchanceRateApp_API.Interfaces;
using Newtonsoft.Json;

namespace ExchanceRateApp_API.Services
{
    public class CurrencyGetterService : ICurrencyGetterService
    {
        private readonly IOuterWebApiDataReceiveService _outerWebApiDataReceiverService;

        public CurrencyGetterService(IOuterWebApiDataReceiveService outerWebApiDataReceiverService)
        {
            _outerWebApiDataReceiverService = outerWebApiDataReceiverService;
        }

        public HistoricalCurrencyDto GetRawCurrencyData()
        {
            string json = _outerWebApiDataReceiverService.GetResponseFromOuterWebAPI().Result;

            HistoricalCurrencyDto currencyDto = JsonConvert.DeserializeObject<HistoricalCurrencyDto>(json);

            return currencyDto;
        }
    }
}
