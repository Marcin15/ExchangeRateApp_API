using Newtonsoft.Json;

namespace ExchangeRateApp_API.Entities
{
    public class FileCurrencySymbol
    {
        [JsonProperty("symbols")]
        public Dictionary<string, string> Symbols { get; set; }
    }
}
