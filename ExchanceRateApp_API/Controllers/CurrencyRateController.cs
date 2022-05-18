using ExchanceRateApp_API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExchanceRateApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyRateController : ControllerBase
    {
        private readonly ILogger<CurrencyRateController> _logger;
        private readonly ICurrencyService _currencyService;
        public CurrencyRateController(ILogger<CurrencyRateController> logger, 
                                      ICurrencyService currencyService)
        {
            _logger = logger;
            _currencyService = currencyService;
        }

        [HttpGet]
        public IActionResult GetCurrencyData()
        {
            var data = _currencyService.GetCurrencyData();

            if(data is null)
            {
                return NotFound();
            }

            return Ok(data);
        }
    }
}
