using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) 
        {
            Database.Migrate();
        }

        public DbSet<Service> Services { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<CompareServices> CompareServices { get; set; }

        public DbSet<FavouriteServices> FavouriteServices { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>().HasData(new List<Service>()
            {
                new Service()
                {
                    CartItems = new List<CartItem>(),
                    Id = Guid.NewGuid(),
                    Cost = 4000,
                    Description = "Поддерживающая уборка вашей квартиры или дома, цена зависит от площади",
                    Link = "/image/image1.jpg",
                    Name = "Поддерживающая уборка"
                },
                 new Service()
                {
                    CartItems = new List<CartItem>(),
                    Id = Guid.NewGuid(),
                    Cost = 5000,
                    Description = "Стандартная уборка вашей квартиры или дома, цена зависит от площади",
                    Link = "/image/image2.jpg",
                    Name = "Стандартная уборка"
                },
                  new Service()
                {
                    CartItems = new List<CartItem>(),
                    Id = Guid.NewGuid(),
                    Cost = 10000,
                    Description = "Генеральная уборка вашей квартиры или дома, цена зависит от площади",
                    Link = "/image/image3.jpeg",
                    Name = "Генеральная уборка"
                },
            }) ;
        }
    }
}
