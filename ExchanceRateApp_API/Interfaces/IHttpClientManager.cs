
namespace ExchanceRateApp_API.Interfaces
{
    public interface IHttpClientManager
    {
        HttpClient GetHttpCliet(string baseUrl);
    }
}