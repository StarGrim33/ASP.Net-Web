using Microsoft.AspNetCore.Identity;
using OnlineShop.Db.Models;
using Serilog;
using Diamond_Cleaning.DI;

namespace Diamond_Cleaning
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseSerilog((context, configuration) => configuration
            .ReadFrom.Configuration(context.Configuration)
            .Enrich.WithProperty("DiamondClining", "Online Shop"));

            builder.Services.AddApplication();
            builder.Services.AddDataAccessLayer(builder.Configuration);

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromHours(8);
                options.LoginPath = "/Authorization/Login";
                options.LogoutPath = "/Authorization/Logout";
                options.Cookie = new CookieBuilder
                {
                    IsEssential = true
                };
            });

            builder.Services.InitRepositories();
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            using (var serviceScope = app.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                var userManager = services.GetRequiredService<UserManager<User>>();
                var rolesManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                IdentityInitializer.Initialize(userManager, rolesManager);
            }

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
