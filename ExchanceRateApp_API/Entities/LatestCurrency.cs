using Newtonsoft.Json;

namespace ExchangeRateApp_API.Entities
{
    public class LatestCurrency
    {
        [JsonProperty("base")]
        public string Base { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("rates")]
        public Dictionary<string, float> Rates { get; set; }
    }
}
