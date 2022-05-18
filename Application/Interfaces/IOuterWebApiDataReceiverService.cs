
namespace Application.Services
{
    public interface IOuterWebApiDataReceiverService
    {
        Task<string> GetResponseFromOuterWebAPI();
    }
}