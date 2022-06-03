using Newtonsoft.Json;

namespace ExchangeRateApp_API.Helpers
{
    public class Serializer
    {
        public static string Serialize(object obj)
        {
            var options = new JsonSerializerSettings();
            options.Formatting = Formatting.Indented;
            options.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;

            return JsonConvert.SerializeObject(obj);
        }
    }
}
