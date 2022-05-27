using System.ComponentModel.DataAnnotations;

namespace ExchangeRateApp_API.Queries
{
    public class LatestCurrencyQuery
    {
        [Required]
        public string BaseCurrrency { get; set; }

        [Required]
        public string[] ExchanceCurrency { get; set; }
    }
}
