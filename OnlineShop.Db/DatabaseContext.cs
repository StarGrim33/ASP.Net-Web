using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        public DbSet<Service> Services { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<CompareServices> CompareServices { get; set; }

        public DbSet<FavouriteServices> FavouriteServices { get; set; }
    }
}
