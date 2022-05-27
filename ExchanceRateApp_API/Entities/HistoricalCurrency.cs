using Newtonsoft.Json;

namespace ExchangeRateApp_API.Entities
{
    public class HistoricalCurrency
    {
        [JsonProperty("base")]
        public string BaseCurrency { get; set; }

        [JsonProperty("start_date")]
        public DateTime StartTime { get; set; }

        [JsonProperty("end_date")]
        public DateTime EndTime { get; set; }

        [JsonProperty("rates")]
        // Date CurrencySymbol CurrencyValue
        public Dictionary<DateTime, Dictionary<string, float>> Rates { get; set; } = new Dictionary<DateTime, Dictionary<string, float>>();
    }
}
