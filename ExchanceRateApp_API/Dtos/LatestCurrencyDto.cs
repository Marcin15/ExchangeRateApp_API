namespace ExchangeRateApp_API.Dtos
{
    public class LatestCurrencyDto
    {
        public string Base { get; set; }
        public DateTime Date { get; set; }
        public Dictionary<string, float> Rates { get; set; }
    }
}
