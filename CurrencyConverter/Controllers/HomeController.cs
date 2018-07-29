using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CurrencyConverter.Models;
using CurrencyConverter.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

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

            var sl = new SelectList(currencies);
            sl.First(x => x.Text == "EUR").Selected = true;

            ViewData["SelectList"] = sl;
            return View();
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
        [ValidateAntiForgeryToken]
        public IActionResult OnGetHistoricalData(string currencyFrom, string currencyTo)
        {
            var first = _currencyDbContext.ExchangeRates.Where(x => x.Currency == currencyFrom);
            var second = _currencyDbContext.ExchangeRates.Where(x => x.Currency == currencyTo);

            var result = (from f in first
                         join s in second on f.Time equals s.Time orderby f.Time
                         select new {y =  f.Rate / s.Rate, x = f.Time }).ToList();

            return Json(result);
        }
    }
}
