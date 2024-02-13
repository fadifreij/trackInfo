using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SearchEngine.Models;
using SearchEngine.Models.Repositories;
using SearchEngine.Services.SearchService;
using System;

namespace SearchEngine
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            builder.Services.AddScoped<IEngineRepository, EngineRepository>();
            builder.Services.AddScoped<ISearchInfoRepository, SearchInfoRepository>();
            builder.Services.AddScoped<ISearchService, SearchService>();

            builder.Services.AddControllersWithViews();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}