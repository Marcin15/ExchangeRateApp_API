using ExchangeRateApp_API.Exceptions;
using ExchangeRateApp_API.Interfaces;

namespace ExchangeRateApp_API.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        private readonly IArgumentNullExceptionHandler _argumentNullExceptionHandler;

        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger, 
                                       IArgumentNullExceptionHandler argumentNullExceptionHandler)
        {
            _logger = logger;
            _argumentNullExceptionHandler = argumentNullExceptionHandler;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (ArgumentNullException ex)
            {
                await _argumentNullExceptionHandler.HandleAsync(context, ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync("Something went wrong");
            }
        }
    }
}
