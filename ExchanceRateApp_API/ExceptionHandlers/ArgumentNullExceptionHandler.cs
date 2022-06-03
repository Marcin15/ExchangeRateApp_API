using ExchangeRateApp_API.Interfaces;

namespace ExchangeRateApp_API.ExceptionHandlers
{
    public class ArgumentNullExceptionHandler : IArgumentNullExceptionHandler
    {
        private readonly ILogger<ArgumentNullExceptionHandler> _logger;
        public ArgumentNullExceptionHandler(ILogger<ArgumentNullExceptionHandler> logger)
        {
            _logger = logger;
        }
        public async Task HandleAsync(HttpContext context, Exception ex)
        {
            string message = $"{ex}\nMessage: {ex.Message}";
            _logger.LogCritical(message);

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsync("Something went wrong");
        }
    }
}
