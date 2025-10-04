using CurrencyTerminal.App.Common;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyTerminal.WebApi.Common
{
    [ApiController]
    public class BaseController: ControllerBase
    {
        protected IActionResult HandleResult<T>(Result<T> result)
        {
            if (result.IsSuccess)
                return Ok(result);

            return NotFound(result.Error);
        }

        protected IActionResult HandleResult(Result result)
        {
            if (result.IsSuccess)
                return NoContent();

            return BadRequest(result.Error);
        }
    }
}
