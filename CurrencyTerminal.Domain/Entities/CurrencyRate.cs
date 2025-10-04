
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CurrencyTerminal.Domain.Entities
{
    public class CurrencyRate: IEquatable<CurrencyRate>
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public double Rate { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;

        public static CurrencyRate Create
            (string code,
            string name,
            double value,
            DateTime date)
        {
            return new CurrencyRate
            {
                Code = code,
                Name = name,
                Rate = value,
                Date = date
            };
        }
        public bool Equals(CurrencyRate? other)
        {
            if (other is null) return false;

            return (Code == other.Code) && (Date.Date == other.Date.Date)
                && (Rate == other.Rate);
        }
    }
}
