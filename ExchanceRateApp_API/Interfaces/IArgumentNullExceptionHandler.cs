
namespace ExchangeRateApp_API.Interfaces
{
    public interface IArgumentNullExceptionHandler
    {
        Task HandleAsync(HttpContext context, Exception ex);
    }
}