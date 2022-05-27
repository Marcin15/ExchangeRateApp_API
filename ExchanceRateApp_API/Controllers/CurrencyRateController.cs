using ExchangeRateApp_API.Interfaces;
using ExchangeRateApp_API.Queries;
using Microsoft.AspNetCore.Mvc;

namespace ExchanceRateApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyRateController : ControllerBase
    {
        private readonly ILogger<CurrencyRateController> _logger;
        private readonly IHistoricalCurrencyService _historicalCurrencyService;
        private readonly ILatestCurrencyService _latestCurrencyService;
        public CurrencyRateController(ILogger<CurrencyRateController> logger,
                                      IHistoricalCurrencyService currencyService, 
                                      ILatestCurrencyService latestCurrencyService)
        {
            _logger = logger;
            _historicalCurrencyService = currencyService;
            _latestCurrencyService = latestCurrencyService;
        }

        [HttpPost]
        [Route("historicalCurrencyData")]
        public IActionResult GetHistoricalCurrencyData(HistoricalCurrencyQuery historicalCurrencyRequestDto)
        {
            var data = _historicalCurrencyService.GetHistoricalCurrency(historicalCurrencyRequestDto);

            if(data is null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpPost]
        [Route("latestCurrencyData")]
        public IActionResult GetLatestCurrencyData(LatestCurrencyQuery latestCurrencyRequestDto)
        {
            var data = _latestCurrencyService.GetLatestCurrency(latestCurrencyRequestDto);

            if (data is null)
            {
                return NotFound();
            }

            return Ok(data);
        }
    }
}
