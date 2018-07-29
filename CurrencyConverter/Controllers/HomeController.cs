using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CurrencyConverter.Models;
using CurrencyConverter.Data;

namespace CurrencyConverter.Controllers
{
    public class HomeController : Controller
    {

        private readonly CurrencyConverterDbContext _currencyDbContext;
        public HomeController(CurrencyConverterDbContext context)
        {
            this._currencyDbContext = context;
        }
        public IActionResult Index()
        {
            var currencies = _currencyDbContext.ExchangeRates.Select(x => x.Currency).Distinct().OrderBy(x => x);
            return View(currencies);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [ValidateAntiForgeryToken]
        public IActionResult OnGetExchangeRate(ExchangeQueryModel parameters)
        {
            if (ModelState.IsValid)
            {
                var time = _currencyDbContext.ExchangeRates.Max(x => x.Time);

                var euro_sum = parameters.Amount / _currencyDbContext.ExchangeRates.First(x => x.Currency == parameters.CurrencyFrom && x.Time == time).Rate;

                var target_rate = _currencyDbContext.ExchangeRates.First(x => x.Currency == parameters.CurrencyTo && x.Time == time).Rate;

                return Json(euro_sum * target_rate);
            }
            else throw new Exception("Invalid model");
        }
    }
}
