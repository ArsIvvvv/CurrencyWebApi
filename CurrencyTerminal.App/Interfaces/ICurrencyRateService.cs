using CurrencyTerminal.App.Common;
using CurrencyTerminal.App.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyTerminal.App.Interfaces
{
    public interface ICurrencyRateService
    {
        Task <Result<IEnumerable<CurrencyRateDto>>> GetAllCurrencyRates(DateTime? onDate = null);
        Task<Result<Dictionary<string,string>>> GetAllCurrencyCodesAsync();
        Task<Result<CurrencyRateDto>> GetCurrencyRateAsync(string currenctCode, DateTime? onDate = null);
    }
}
