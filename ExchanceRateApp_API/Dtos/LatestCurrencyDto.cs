using Newtonsoft.Json;

namespace ExchanceRateApp_API.Dtos
{
    public class LatestCurrencyDto
    {
        [JsonProperty("base")]
        public string Base { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("rates")]
        public Dictionary<string, float> Rates { get; set; }
    }
}
