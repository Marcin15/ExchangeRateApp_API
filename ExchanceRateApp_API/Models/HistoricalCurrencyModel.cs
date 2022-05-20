namespace ExchanceRateApp_API.Models
{
    public class HistoricalCurrencyModel
    {
        public string Symbol { get; set; }
        public Dictionary<DateTime, float> Rates { get; set; }
    }
}
