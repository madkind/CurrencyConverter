using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConverter.Data
{
    public class CurrencyConverterDbContext : DbContext
    {
        public CurrencyConverterDbContext(DbContextOptions<CurrencyConverterDbContext> options)
            : base(options)
        {
            this.ExchangeRates.AddRange(new ExchangeManager().GetExchangeRates());
            this.SaveChanges();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExchangeRate>()
                .HasKey(c => new { c.Currency, c.Time });
        }

        public DbSet<ExchangeRate> ExchangeRates { get; set; }
    }
}
