using ExchangeRateApp_API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExchanceRateApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencySymbolsController : ControllerBase
    {
        private readonly ICurrencySymbolsFileReadService _currencySymbolsFileReadService;
        private readonly ILogger<CurrencyRateController> _logger;

        public CurrencySymbolsController(ICurrencySymbolsFileReadService currencySymbolsFileReadService,
                                         ILogger<CurrencyRateController> logger)
        {
            _currencySymbolsFileReadService = currencySymbolsFileReadService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetSymbols()
        {
            _logger.LogError("witam");
            var symbols = _currencySymbolsFileReadService.ReadSymbols();

            if(symbols is null)
            {
                return NotFound();
            }
            return Ok(symbols);
        }
    }
}
