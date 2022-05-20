using ExchanceRateApp_API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExchanceRateApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyRateController : ControllerBase
    {
        private readonly ILogger<CurrencyRateController> _logger;
        private readonly IHistoricalCurrencyService _currencyService;
        private readonly ILatestCurrencyService _latestCurrencyService;
        public CurrencyRateController(ILogger<CurrencyRateController> logger,
                                      IHistoricalCurrencyService currencyService, 
                                      ILatestCurrencyService latestCurrencyService)
        {
            _logger = logger;
            _currencyService = currencyService;
            _latestCurrencyService = latestCurrencyService;
        }

        [HttpGet]
        [Route("historicalCurrencyData")]
        public IActionResult GetHistoricalCurrencyData(string baseCurrency, string exchanceCurrency, DateTime startDate, DateTime endDate)
        {
            var data = _currencyService.GetHistoricalCurrencyData(baseCurrency, exchanceCurrency, startDate, endDate);

            if(data is null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("latestCurrencyData")]
        public IActionResult GetLatestCurrencyData(string baseCurrency, string exchanceCurrency)
        {
            var data = _latestCurrencyService.GetLatestCurrency(baseCurrency, exchanceCurrency);

            if (data is null)
            {
                return NotFound();
            }

            return Ok(data);
        }
    }
}
