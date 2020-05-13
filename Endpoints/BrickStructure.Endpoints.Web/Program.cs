using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace BrickStructure.Endpoints.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var env = hostingContext.HostingEnvironment;
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                    config.AddEnvironmentVariables();
                })
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    //logging.AddConsole(); // Envía la información de la ventana "Depurar" al log
                    //logging.AddDebug(); // Registra lo escrito por System.Diagnostics.Debug.WriteLine
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel((context, opt) =>
                    {
                        // Elimina el límite de tamaño en las peticiones (Lo que antes era MaxJsonLength)
                        opt.Limits.MaxRequestBodySize = 4L * 1024L * 1024L * 1024L; // 4GB
                        opt.Limits.MaxRequestBufferSize = 5L * 1024L * 1024L; // Bytes (5Mb)
                        opt.Limits.MaxRequestHeaderCount = 1000;
                        opt.Limits.MaxRequestHeadersTotalSize = 128 * 1024; // Bytes (128Kb)
                        opt.Limits.MaxRequestLineSize = 128 * 1024; // Bytes (128Kb)
                        opt.Limits.MaxConcurrentConnections = null;
                        opt.Limits.RequestHeadersTimeout = TimeSpan.FromMinutes(5);
                        opt.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(10);

                        opt.AddServerHeader = false;
                    });

                    webBuilder.UseIISIntegration();
                    webBuilder.UseStartup<Startup>();
                });
    }
}
