namespace ExchanceRateApp_API.Models
{
    public class CurrencyModel
    {
        public string Symbol { get; set; }
        public Dictionary<DateTime, float> CurrencyValue { get; set; }
        //public DateTime Date { get; set; }
        //public float CurrencyValue { get; set; }
    }
}
