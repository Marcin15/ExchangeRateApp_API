using Newtonsoft.Json;

namespace ExchanceRateApp_API.Dtos
{
    public class HistoricalCurrencyDto
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
