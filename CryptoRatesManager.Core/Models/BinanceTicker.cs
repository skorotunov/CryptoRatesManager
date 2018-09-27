using Newtonsoft.Json;
using System;

namespace CryptoRatesManager.Core.Models
{
    internal class BinanceTicker
    {
        /// <summary>
        /// Best bid price. eg: "0.0024"
        /// </summary>
        [JsonProperty("b")]
        public decimal BidPrice { get; set; }

        /// <summary>
        /// Best bid quantity. eg: "10"
        /// </summary>
        [JsonProperty("B")]
        public decimal BidQuantity { get; set; }

        /// <summary>
        /// Best ask price. eg: "0.0026"
        /// </summary>
        [JsonProperty("a")]
        public decimal AskPrice { get; set; }

        /// <summary>
        /// Best ask quantity. eg: "100"
        /// </summary>
        [JsonProperty("A")]
        public decimal AskQuantity { get; set; }

        /// <summary>
        /// Event type. eg: "24hrTicker"
        /// </summary>
        [JsonProperty("e")]
        public string EventType { get; set; }

        /// <summary>
        /// Event time in milliseconds. eg: 123456789
        /// </summary>
        [JsonProperty("E")]
        public DateTime EventTime { get; set; }
    }
}
