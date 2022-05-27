using System.ComponentModel.DataAnnotations;

namespace ExchangeRateApp_API.Queries
{
    public class HistoricalCurrencyQuery
    {
        [Required]
        public string BaseCurrency { get; set; }

        [Required]
        public string[] ExchangeCurrency { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
    }
}
