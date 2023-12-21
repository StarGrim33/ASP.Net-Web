using Diamond_Cleaning.Interfaces;
using Diamond_Cleaning.Models;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Db;
using Serilog;

namespace Diamond_Cleaning
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string connection = builder.Configuration.GetConnectionString("OnlineShop");

            builder.Host.UseSerilog((context, configuration) => configuration
            .ReadFrom.Configuration(context.Configuration)
            .Enrich.WithProperty("DiamondClining", "Online Shop"));

            // Add services to the container.
            builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection));
            builder.Services.AddSingleton<IRolesRepository, InMemoryRolesRepository>();
            builder.Services.AddSingleton<IUsersRepository, UsersInMemoryRepository>();
            builder.Services.AddTransient<IServicesRepository, ServiceDbRepository>();
            builder.Services.AddTransient<ICartsRepository, CartsDbRepository>();
            builder.Services.AddSingleton<IOrdersRepository, OrdersInMemoryRepository>();
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSerilogRequestLogging();

            app.MapControllerRoute(
                name: "MyArea",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}"
                );

            app.Run();
        }
    }
}
