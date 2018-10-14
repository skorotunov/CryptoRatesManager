using CryptoRatesManager.Core.Providers;
using CryptoRatesManager.Core.Services.Abstract;
using CryptoRatesManager.Core.Services.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
            return View();
        }
    }
}
