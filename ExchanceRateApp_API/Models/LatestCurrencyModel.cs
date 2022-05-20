namespace ExchanceRateApp_API.Models
{
    public class LatestCurrencyModel
    {
        public string Base { get; set; }
        public DateTime Date { get; set; }
        public Dictionary<string, float> Rates { get; set; }
    }
}
