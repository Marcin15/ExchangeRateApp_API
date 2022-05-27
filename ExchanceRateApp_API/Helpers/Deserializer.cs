using Newtonsoft.Json;

namespace ExchangeRateApp_API.Helpers
{
    public class Deserializer
    {
        public static T Deserialize<T>(string json) => JsonConvert.DeserializeObject<T>(json);
    }
}
