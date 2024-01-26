using Diamond_Cleaning.Interfaces;
using Diamond_Cleaning.Mapper;
using Diamond_Cleaning.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Db;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;
using System.Composition;

namespace Diamond_Cleaning.DI
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AuthoMap));
        }

        public static void InitRepositories(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<IdentityContext>();
            services.AddSingleton<IRolesRepository, InMemoryRolesRepository>();
            services.AddTransient<IServicesRepository, ServiceDbRepository>();
            services.AddTransient<ICompareServices, CompareDbRepository>();
            services.AddTransient<IFavouriteRepository, FavouriteDbRepository>();
            services.AddTransient<ICartsRepository, CartsDbRepository>();
            services.AddTransient<IOrdersRepository, OrdersDbRepository>();
        }

        public static void AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            string connection = configuration.GetConnectionString("OnlineShop");
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection));
            services.AddDbContext<IdentityContext>(options => options.UseSqlServer(connection));
        }
    }
}
