using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ANU.Data;
using System;
using Microsoft.Extensions.Logging;
//yo;
namespace ANU
{
    // This is the entry point class for the application
    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            // OPTIONAL: Initialize the database with seed data on application startup
            // This is useful for development and testing
            // using (var scope = host.Services.CreateScope())
            // {
            //     var services = scope.ServiceProvider;
            //     try
            //     {
            //         var context = services.GetRequiredService<ApplicationDbContext>();
            //         // Apply any pending migrations
            //         context.Database.Migrate();
            //         // Seed the database if needed
            //         // SeedData.Initialize(context);
            //     }
            //     catch (Exception ex)
            //     {
            //         var logger = services.GetRequiredService<ILogger<EntryPoint>>();
            //         logger.LogError(ex, "An error occurred while seeding the database.");
            //     }
            // }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
