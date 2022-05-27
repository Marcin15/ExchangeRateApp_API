namespace ExchangeRateApp_API.Dtos
{
    public class HistoricalCurrencyDtos
    {
        public string Symbol { get; set; }
        public Dictionary<DateTime, float> Rates { get; set; }
    }
}
