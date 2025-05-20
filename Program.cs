using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Data.Interfaces;
using OnlineShop.Data.Models;
using OnlineShop.Data.Repository;

namespace OnlineShop
{
    public class Program
    {

        public static void Main(string[] args)
        {


            var builder = WebApplication.CreateBuilder(args);

            //var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // Строка подключения для Render.com
            var connectionString = Environment.GetEnvironmentVariable("RENDER_SQL_CONNECTION")
                       ?? builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddScoped(sp => ShopCart.GetCar(sp));
            builder.Services.AddScoped<IAllCars, CarRepository>();
            builder.Services.AddScoped<ICarsCategory, CategoryRepository>();
            builder.Services.AddScoped<IAllOrders, OrdersRepository>();

            builder.Services.AddMvc(options => options.EnableEndpointRouting = false);

            //builder.Services.AddHttpsRedirection(options =>
            //{
            //    options.HttpsPort = 443; // Порт HTTPS по умолчанию
            //});

            builder.WebHost.ConfigureKestrel(serverOptions =>
            {
                serverOptions.ListenAnyIP(5000); // Render использует порт 5000
            });

            builder.Services.AddMemoryCache();
            builder.Services.AddSession();

            var app = builder.Build();

            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvcWithDefaultRoute();

            //app.UseHttpsRedirection();
            app.UseRouting();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "categoryFilter",
                pattern: "Cars/{action}/{category?}",
                defaults: new { Controller = "Cars", action = "CarsList" });

            using (var scope = app.Services.CreateScope())
            {
                ApplicationDbContext appContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                DbObjects.Initial(appContext);
            }




            app.Run();
        }
    }
}
