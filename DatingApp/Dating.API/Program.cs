using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using Dating.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Dating.API
{
    public class Program
    {
        public static void Main(string[] args)
        {

           var host= CreateHostBuilder(args).Build();
           using (var scope =host.Services.CreateScope())
           {
               var services =scope.ServiceProvider;
               try
               {
                  var context = services.GetRequiredService<DataContext>();
                  context.Database.Migrate();
                  Seed.SeedUsers(context);
               }
               catch(Exception ex)
               {
                   var logger = services.GetRequiredService<ILogger<Program>>();
                   logger.LogError(ex,"an error occured durin migration");
               }

           }
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
