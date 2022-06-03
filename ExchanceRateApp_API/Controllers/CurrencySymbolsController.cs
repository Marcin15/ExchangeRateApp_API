using ExchangeRateApp_API.Entities;
using ExchangeRateApp_API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExchanceRateApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencySymbolsController : ControllerBase
    {
        private readonly ICurrencySymbolsFileReadService _currencySymbolsFileReadService;

        public CurrencySymbolsController(ICurrencySymbolsFileReadService currencySymbolsFileReadService)
        {
            _currencySymbolsFileReadService = currencySymbolsFileReadService;
        }

        [HttpGet]
        public IActionResult GetSymbols()
        {
            var symbols = _currencySymbolsFileReadService.ReadSymbols();

            return Ok(symbols);
        }
    }
}
