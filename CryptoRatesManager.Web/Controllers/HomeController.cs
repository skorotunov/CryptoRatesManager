using CryptoRatesManager.Core.Providers;
using CryptoRatesManager.Core.Services.Abstract;
using CryptoRatesManager.Core.Services.Concrete;
using CryptoRatesManager.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;

namespace CryptoRatesManager.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var service = new MainWebSocketProvider(
                new List<IWebSocketClient>
                {
                    new BinanceWebSocketClient("ethbtc"),
                    new HitBTCWebSocketClient("ethbtc"),
                    new BinanceWebSocketClient("btcusdt"),
                    new HitBTCWebSocketClient("btcusdt")
                },
                1);
            service.StartExecution();
            return this.View();
        }

        public IActionResult About()
        {
            this.ViewData["Message"] = "Your application description page.";

            return this.View();
        }

        public IActionResult Contact()
        {
            this.ViewData["Message"] = "Your contact page.";

            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
