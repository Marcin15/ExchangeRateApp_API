using ExchanceRateApp_API.Interfaces;
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

            if(symbols is null)
            {
                return NotFound();
            }
            return Ok(symbols);
        }
    }
}
