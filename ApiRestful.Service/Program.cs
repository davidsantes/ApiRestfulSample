using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using Serilog;
using Serilog.Formatting.Compact;

namespace ApiRestful.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Configuration log with Serilog
            Log.Logger = new LoggerConfiguration()
                            .Enrich.FromLogContext()                            
                            .WriteTo.Console(new RenderedCompactJsonFormatter())
                            .WriteTo.Debug(outputTemplate: DateTime.Now.ToString())
                            .WriteTo.File("ApiRestfulServiceLog.txt", rollingInterval: RollingInterval.Day)
                            .CreateLogger();
                            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
