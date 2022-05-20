using Newtonsoft.Json;

namespace ExchanceRateApp_API.Helpers
{
    public class Serializer
    {
        public static string Serialize(object obj) => JsonConvert.SerializeObject(obj, Formatting.Indented);
    }
}
