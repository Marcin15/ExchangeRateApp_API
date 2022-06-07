namespace ExchangeRateApp_API.Interfaces
{
    public interface IOuterWebApiDataReciveCreator<T> where T : class
    {
        ICurrencyRatesService<T> GetService(T querry);
    }
}