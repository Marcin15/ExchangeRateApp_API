using Newtonsoft.Json;

namespace ExchangeRateApp_API.Helpers
{
    public class Serializer
    {
        public static string Serialize(object obj) => JsonConvert.SerializeObject(obj, Formatting.Indented);
    }
}
