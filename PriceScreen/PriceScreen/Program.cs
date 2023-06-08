using Microsoft.EntityFrameworkCore;
using PriceScreen.Data;
using PriceScreen.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

//builder.Services.AddDbContext<PriceScreenDbContext>(item => item.UseSqlServer(configuration.GetConnectionString("myconn")));

builder.Services.AddDbContext<PriceScreenDbContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnectionStrings")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthentication(); 

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

//var provider = builder.Services.BuildServiceProvider();
//var configuration = provider.GetRequiredService<IConfiguration>();