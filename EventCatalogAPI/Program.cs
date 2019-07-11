using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EventCatalogAPI.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EventCatalogAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
           //CreateWebHostBuilder(args).Build().Run();
            var host = CreateWebHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
             {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<CatalogContext>();
                CatalogSeed.Seed(context);
            }
            host.Run();
        }
                public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
                    WebHost.CreateDefaultBuilder(args)
                        .UseStartup<Startup>();
    }
}
