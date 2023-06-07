using Microsoft.EntityFrameworkCore;
using PriceScreen.Models;

namespace PriceScreen.DBContext
{
    public class PriceScreenDBContext : DbContext
    {
        public PriceScreenDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
