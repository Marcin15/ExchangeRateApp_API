namespace ExchangeRateApp_API.Interfaces
{
    public interface IHttpClientManager
    {
        HttpClient GetHttpCliet(string baseUrl);
    }
}