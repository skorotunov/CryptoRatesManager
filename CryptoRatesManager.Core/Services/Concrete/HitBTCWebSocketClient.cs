using CryptoRatesManager.Core.Models;
using CryptoRatesManager.Core.Services.Abstract;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebSocketSharp;

namespace CryptoRatesManager.Core.Services.Concrete
{
    public class HitBTCWebSocketClient : IWebSocketClient
    {
        private readonly string url;
        private readonly string currency;
        private readonly object lockObject = new object();

        public HitBTCWebSocketClient(string currency)
        {
            this.url = "wss://api.hitbtc.com/api/2/ws";
            this.currency = currency;
        }

        private WebSocket WebSocket { get; set; }

        private HitBTCTicker Ticker { get; set; }

        public void Subscribe()
        {
            this.WebSocket = new WebSocket(this.url);
            this.WebSocket.OnMessage += (sender, e) =>
            {
                if (!e.Data.Contains("result"))
                {
                    lock (this.lockObject)
                    {
                        this.Ticker = JsonConvert.DeserializeObject<HitBTCTicker>(e.Data);
                    }
                }
            };
            this.WebSocket.OnError += (sender, e) =>
            {
            };
            this.WebSocket.Connect();
            var request = $"{{ \"method\": \"subscribeTicker\", \"params\": {{ \"symbol\": \"{this.currency.ToUpper()}\" }}, \"id\": 123 }}";
            this.WebSocket.Send(request);
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
