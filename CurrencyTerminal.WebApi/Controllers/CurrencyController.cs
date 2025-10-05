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

        [HttpGet("all-codes")]
        public async Task<IActionResult> GetAllCodesRatesAsync()
        {
            var rates = await _currencyRateService.GetAllCurrencyCodesAsync();
            return HandleResult<Dictionary<string, string>>(rates);
        }

        [HttpGet("currency_rate/{date?}/{code}")]
        public async Task<IActionResult> GetAllCurrencyRatesAsync([FromRoute] DateTime? date, [FromRoute] string code)
        {
            var rates = await _currencyRateService.GetCurrencyRateAsync(code,date);
            return HandleResult<CurrencyRateDto>(rates);
        }
    }
}
