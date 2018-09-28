using System;

namespace CryptoRatesManager.DAL.Models
{
    public class Ticker
    {
        public int ID { get; set; }

        public int ExchangeID { get; set; }

        public int CurrencyID { get; set; }

        public decimal BidPrice { get; set; }

        public decimal AskPrice { get; set; }

        public DateTime Date { get; set; }

        public virtual Exchange Exchange { get; set; }

        public virtual Currency Currency { get; set; }
    }
}
