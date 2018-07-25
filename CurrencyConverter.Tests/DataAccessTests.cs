using CurrencyConverter.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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
        public void XmlParse()
        {
            var envelope = new ExchangeManager().GetSerializedData();
            Assert.True(envelope != null && envelope.Cube.Length > 0);
        }
        [Fact]
        public void ExchangeRateConversion()
        {
            var rates = new ExchangeManager().GetExchangeRates();
            Assert.True(rates.Any());
        }
        [Fact]
        public void DbContext()
        {
            var context = new CurrencyConverterDbContext(
                new DbContextOptionsBuilder<CurrencyConverterDbContext>()
                .UseInMemoryDatabase("currencydb").Options);
            Assert.True(context.ExchangeRates.Any());
        }
    }
}
