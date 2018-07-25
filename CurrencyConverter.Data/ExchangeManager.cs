using System;

namespace CurrencyConverter.Data
{
    public class ExchangeManager
    {
        public Envelope GetData() {
            string xml = DownloadXml();
            return Helpers.ParseHelpers.ParseXML<Envelope>(xml);
        }

        public string DownloadXml() {
            return new System.Net.WebClient().DownloadString("http://www.ecb.europa.eu/stats/eurofxref/eurofxref-hist-90d.xml");
        }
    }
}
