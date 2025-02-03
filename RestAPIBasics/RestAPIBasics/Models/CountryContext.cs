using Microsoft.EntityFrameworkCore;

namespace RestAPIBasics.Models
{
    public class CountryContext : DbContext
    {
        public CountryContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<CountryData> CountryData { get; set; }
    }
}
