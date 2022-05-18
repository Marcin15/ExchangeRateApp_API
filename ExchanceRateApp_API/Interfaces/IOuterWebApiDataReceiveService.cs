
namespace ExchanceRateApp_API.Interfaces
{
    public interface IOuterWebApiDataReceiveService
    {
        Task<string> GetResponseFromOuterWebAPI();
    }
}