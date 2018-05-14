using ch.cena.swiper.backend.data;
using ch.cena.swiper.backend.data.Models;
using ch.cena.swiper.backend.service.Contracts.Service;
using ch.cena.swiper.backend.service.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System;
using System.IO;

using System.Linq;

namespace CenaPipelineExport
{
    class Program { 
    
        public static void Main(string[] args)
        {
            var servicesProvider = BuildDi();
            var runner = servicesProvider.GetRequiredService<Runner>();

            runner.Export();

            Console.WriteLine("Press ANY key to exit");
            Console.ReadLine();

            // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
            NLog.LogManager.Shutdown();
        }


        private static IServiceProvider BuildDi()
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var config = configBuilder.Build();

            var services = new ServiceCollection();

            services.AddEntityFrameworkNpgsql().AddDbContext<SwiperContext>(
                options => options.UseNpgsql(config.GetConnectionString("PostgresConnection")));

            //Runner is the custom class
            services.AddTransient<Runner>();

            //Loggin service
            services.AddSingleton<ILoggerFactory, LoggerFactory>();
            services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
            services.AddLogging((builder) => builder.SetMinimumLevel(LogLevel.Trace));

            //Add Database Services
            services.AddTransient<IAnnotationService, AnnotationService>();


            var serviceProvider = services.BuildServiceProvider();

            var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

            //configure NLog
            loggerFactory.AddNLog(new NLogProviderOptions { CaptureMessageTemplates = true, CaptureMessageProperties = true });
            NLog.LogManager.LoadConfiguration("nlog.config");

            return serviceProvider;
        }
    }
}
