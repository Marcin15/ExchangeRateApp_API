using ExchangeRateApp_API.Interfaces;
using ExchangeRateApp_API.Queries;
using Microsoft.AspNetCore.Mvc;

namespace ExchanceRateApp_API.Controllers
{
    [Produces("application/json")]
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
        /// <summary>
        /// Retrieves a list of currency rates specified by date interval
        /// </summary>
        /// <param name="historicalCurrencyRequestDto"></param>
        /// <remarks>
        /// Sample request:
        ///
        /// **BaseCurrency**: PLN
        /// <br/>
        /// **ExchangeCurrency**: EUR, USD
        /// <br/>
        /// **StartDate**: 2022-05-14
        /// <br/>
        /// **EndDate**: 2022-06-02
        ///
        /// </remarks>
        /// <response code="200">Request is correct</response>
        /// <response code="400">Product has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your product right now</response>
        [HttpGet]
        [Route("historicalCurrencyData")]
        public async Task<IActionResult> GetHistoricalCurrencyData([FromQuery] HistoricalCurrencyQuery historicalCurrencyRequestDto)
        {
            var data = await _historicalCurrencyService.GetHistoricalCurrencyAsync(historicalCurrencyRequestDto);

            if(data is null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        /// <summary>
        /// Retrieves a list of currency rates specified by current date
        /// </summary>
        /// <param name="latestCurrencyRequestDto">asd</param>
        /// <remarks>
        /// Sample request:
        ///
        /// **BaseCurrency**: PLN
        /// <br/>
        /// **ExchangeCurrency**: EUR, USD
        /// </remarks>
        /// <response code="200">Request is correct</response>
        /// <response code="400">Product has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your product right now</response>
        [HttpGet]
        [Route("latestCurrencyData")]
        public async Task<IActionResult> GetLatestCurrencyData([FromQuery] LatestCurrencyQuery latestCurrencyRequestDto)
        {
            var data = await _latestCurrencyService.GetLatestCurrencyAsync(latestCurrencyRequestDto);

            if (data is null)
            {
                return NotFound();
            }

            return Ok(data);
        }
    }
}
