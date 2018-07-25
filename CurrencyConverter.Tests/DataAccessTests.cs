using CurrencyConverter.Data;
using System;
using Xunit;

namespace CurrencyConverter.Tests
{
    public class DataAccessTests
    {
        [Fact]
        public void XmlDownload()
        {
            string xml = new ExchangeManager().DownloadXml();
            Console.WriteLine(xml);
            Assert.True(xml.Length > 0);
        }
        [Fact]
        public void XmlParse() {
            var envelope = new ExchangeManager().GetData();
            Assert.True(envelope != null);
        }
    }
}
