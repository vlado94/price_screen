using PriceScreen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PriceScreen.Models;
using PriceScreen.Repository;
using Microsoft.EntityFrameworkCore;

namespace PriceScreen
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddRazorPages();
            services.AddDbContext<DatabaseContext>(conn => conn.UseSqlServer
            (Configuration.GetConnectionString("connectionstr")));
            services.AddScoped<ILogin, AuthenticateLogin>();
            services.AddControllersWithViews();
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();
            app.Run();
        }

        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddDbContext<DatabaseContext>(conn => conn.UseSqlServer
        //    (Configuration.GetConnectionString("connectionstr")));
        //    services.AddScoped<ILogin, AuthenticateLogin>();
        //    services.AddControllersWithViews();
        //}

    }
}

