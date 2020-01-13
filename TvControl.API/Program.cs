using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TvControl.API.DataLayer;

namespace TvControl.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Host will run after the data is seeded
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                // when we start the app we are going to seed the DB if there are no genres
                try
                {
                    var context = services.GetRequiredService<DataContext>();

                    // Apply pending migrations and also creates the DB if there is no DB
                    context.Database.Migrate();

                    Seed.SeedGenres(context);
                }
                catch (Exception)
                {

                    var logger = services.GetRequiredService<ILogger<Program>>();

                    logger.LogError("An error occured during migration");
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
