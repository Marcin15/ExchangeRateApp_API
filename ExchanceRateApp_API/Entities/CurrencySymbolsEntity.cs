using Newtonsoft.Json;

namespace ExchanceRateApp_API.Entities
{
    public class CurrencySymbolsEntity
    {
        [JsonProperty("symbols")]
        public Dictionary<string, string> Symbols { get; set; }
    }
}
