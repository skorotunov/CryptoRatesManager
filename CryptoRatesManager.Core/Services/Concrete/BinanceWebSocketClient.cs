using CryptoRatesManager.Core.Converters;
using CryptoRatesManager.Core.Models;
using CryptoRatesManager.Core.Services.Abstract;
using Newtonsoft.Json;
using WebSocketSharp;

namespace CryptoRatesManager.Core.Services.Concrete
{
    public class BinanceWebSocketClient : IWebSocketClient
    {
        private readonly string url;
        private readonly object lockObject = new object();

        public BinanceWebSocketClient(string currency)
        {
            this.url = $"wss://stream.binance.com:9443/ws/{currency.ToLower()}@ticker";
        }

        private WebSocket WebSocket { get; set; }

        private BinanceTicker Ticker { get; set; }

        public void Subscribe()
        {
            this.WebSocket = new WebSocket(this.url);
            this.WebSocket.OnMessage += (sender, e) =>
            {
                lock (this.lockObject)
                {
                    this.Ticker = JsonConvert.DeserializeObject<BinanceTicker>(e.Data, new MillisecondsToDateTimeConverter());
                }
            };
            this.WebSocket.OnError += (sender, e) =>
            {
            };
            this.WebSocket.Connect();
        }

        public void Unsubscribe()
        {
            this.WebSocket.Close();
        }

        public void ProcessData()
        {
        }
    }
}
