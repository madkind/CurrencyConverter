using System;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyConverter.Data
{
    public class ExchangeManager
    {
        public Envelope GetSerializedData()
        {
            string xml = DownloadXml();
            return Helpers.ParseHelpers.ParseXML<Envelope>(xml);
        }

        public string DownloadXml()
        {
            return new System.Net.WebClient().DownloadString("http://www.ecb.europa.eu/stats/eurofxref/eurofxref-hist-90d.xml");
        }

        public IEnumerable<ExchangeRate> GetExchangeRates()
        {
            var exchangeRates = new List<ExchangeRate>();

            var dataPoints = GetSerializedData().Cube.AsEnumerable();
            foreach (var item in dataPoints)
            {
                exchangeRates.AddRange(item.Cube.Select(x =>
                new ExchangeRate()
                {
                    Time = item.time,
                    Currency = x.currency,
                    Rate = x.rate
                }));
            }

            return exchangeRates;
        }

    }
}
