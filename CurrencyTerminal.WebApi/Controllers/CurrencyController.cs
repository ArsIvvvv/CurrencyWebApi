using CurrencyTerminal.App.DTO;
using CurrencyTerminal.App.Interfaces;
using CurrencyTerminal.WebApi.Common;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace CurrencyTerminal.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CurrencyController :BaseController 
    {
        private readonly ICurrencyRateService _currencyRateService;

        public CurrencyController(ICurrencyRateService currencyRateService)
        {
            _currencyRateService = currencyRateService;
        }

        [HttpGet("all-rates/{date?}")]
        public async Task<IActionResult> GetAllCurrencyRatesAsync([FromRoute] DateTime? date)
        {
            var rates = await _currencyRateService.GetAllCurrencyRates(date);
            return HandleResult<IEnumerable<CurrencyRateDto>>(rates); 
        }
    }
}
