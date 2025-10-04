using CurrencyTerminal.Domain.Entities;
using CurrencyTerminal.Domain.Interfaces;
using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace CurrencyTerminal.Infrastructure.Repositories
{
    public class CurrencyRepository : ICurrencyRepository, IDisposable
    {
        private readonly DailyInfoSoapClient _soapClient;
        public CurrencyRepository()
        {
            _soapClient = new DailyInfoSoapClient(DailyInfoSoapClient.EndpointConfiguration.DailyInfoSoap);
        }
        public void Dispose()
        {
           if(_soapClient?.State == CommunicationState.Opening)
           {
               _soapClient.Close();
           }
           else if(_soapClient.State == CommunicationState.Faulted)
           {
               _soapClient.Abort();
           }
        }

        public async Task<IEnumerable<CurrencyRate?>> GetAllCurrencyRateAsync(DateTime? onDate = null)
        {
            var date = onDate?? DateTime.UtcNow;
            var result = new List<CurrencyRate>();

            var response = await _soapClient.GetCursOnDateXMLAsync(date);
            if (response != null)
                return null;

            foreach (XmlNode node in response.ChildNodes)
            {

                var code = node.SelectSingleNode("VchCode")?.InnerText.Trim();
                var name = node.SelectSingleNode("Vname")?.InnerText.Trim();
                double rate = double.TryParse(node.SelectSingleNode("VunitRate")?
                    .InnerText!, CultureInfo.InvariantCulture, out double resRate) ? resRate : 0;

                result.Add(CurrencyRate.Create(code, name, rate, date));
            }

            return result;
        }

        public Task<CurrencyRate?> GetCurrencyRateAsync(string code, DateTime? onDate = null)
        {
            throw new NotImplementedException();
        }
        
    }
}
