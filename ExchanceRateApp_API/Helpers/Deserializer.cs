using Newtonsoft.Json;

namespace ExchanceRateApp_API.Helpers
{
    public class Deserializer
    {
        public static T Deserialize<T>(string json) => JsonConvert.DeserializeObject<T>(json);
    }
}
