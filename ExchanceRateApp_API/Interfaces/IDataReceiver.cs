namespace ExchangeRateApp_API.Interfaces
{
    public interface IDataReceiver
    {
        Task<string> ReceiveDataAsync(string baseUrl, object query);
    }
}
