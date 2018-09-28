using System.Collections.Generic;

namespace CryptoRatesManager.DAL.Models
{
    public class Exchange
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string StreamUrl { get; set; }

        public string Request { get; set; }

        public ICollection<Ticker> Tickers { get; set; }
    }
}
