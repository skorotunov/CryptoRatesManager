using System.Collections.Generic;

namespace CryptoRatesManager.DAL.Models
{
    public class Currency
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public ICollection<Ticker> Tickers { get; set; }
    }
}
