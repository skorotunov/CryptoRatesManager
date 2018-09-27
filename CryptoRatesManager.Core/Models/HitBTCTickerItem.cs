using Newtonsoft.Json;
using System;

namespace CryptoRatesManager.Core.Models
{
    internal class HitBTCTickerItem
    {
        /// <summary>
        /// Best ask price. eg: "0.050043"
        /// </summary>
        [JsonProperty("ask")]
        public decimal AskPrice { get; set; }

        /// <summary>
        /// Best bid price. eg: "0.050042"
        /// </summary>
        [JsonProperty("bid")]
        public decimal BidPrice { get; set; }

        /// <summary>
        /// Last update or refresh ticker timestamps. eg: "2017-05-12T14:57:19.999Z"
        /// </summary>
        [JsonProperty("timestamp")]
        public DateTime EventTime { get; set; }
    }
}
