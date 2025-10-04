using CurrencyTerminal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyTerminal.Domain.Interfaces
{
    public interface ICurrencyRepository
    {
        public Task<IEnumerable<CurrencyRate?>> GetAllCurrencyRateAsync(DateTime? onDate = null);
        public Task<CurrencyRate?> GetCurrencyRateAsync(string code,DateTime? onDate = null);
    }
}
