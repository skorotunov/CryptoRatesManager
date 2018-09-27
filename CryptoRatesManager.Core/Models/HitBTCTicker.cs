using Newtonsoft.Json;

namespace CryptoRatesManager.Core.Models
{
    internal class HitBTCTicker
    {
        [JsonProperty("params")]
        public HitBTCTickerItem Params { get; set; }
    }
}
