using ExchangeRateApp_API.Interfaces;

namespace ExchangeRateApp_API.Services
{
    public class StringArrayToStringMapService : IStringArrayToStringMapService
    {
        public string MapExchangeCurrencyArraytoString(string[] exchangeCurrency)
        {
            string result = "";

            foreach (var currency in exchangeCurrency)
            {
                if ((exchangeCurrency.Last() == currency))
                {
                    result += currency.ToUpper();
                    break;
                }
                result += currency.ToUpper() + ",";
            }

            return result;
        }
    }
}
