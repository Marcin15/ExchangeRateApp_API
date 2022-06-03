namespace ExchangeRateApp_API.Dtos
{
    public class HistoricalCurrencyDto
    {
        public string Symbol { get; set; }
        public Dictionary<DateTime, float> Rates { get; set; }
    }
}
