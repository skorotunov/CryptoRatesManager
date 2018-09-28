using CryptoRatesManager.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CryptoRatesManager.DAL
{
    public class CryptoRatesManagerContext : DbContext
    {
        public CryptoRatesManagerContext(DbContextOptions<CryptoRatesManagerContext> options)
            : base(options)
        {
        }

        public DbSet<Currency> Currency { get; set; }

        public DbSet<Exchange> Exchange { get; set; }

        public DbSet<Ticker> Ticker { get; set; }
    }
}
