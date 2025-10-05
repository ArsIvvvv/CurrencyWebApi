
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
        public int Nominal { get; set; }
        public string Date { get; set; } = DateTime.UtcNow.ToShortDateString();

        public static CurrencyRate Create
            (string code,
            string name,
            double value,
            int nominal)
        {
            return new CurrencyRate
            {
                Code = code,
                Name = name,
                Rate = value,
                Nominal = nominal
            };
        }
        public bool Equals(CurrencyRate? other)
        {
            if (other is null) return false;

            return (Code == other.Code) && (Date == other.Date)
                && (Rate == other.Rate);
        }
    }
}
