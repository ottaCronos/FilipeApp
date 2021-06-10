using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilipeApp.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FilipeApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Global.PlacedItems = DataService.Load();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}