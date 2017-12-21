using ch.cena.swiper.backend.data;
using ch.cena.swiper.backend.service.Contracts;
using ch.cena.swiper.backend.service.Contracts.Configuration;
using ch.cena.swiper.backend.service.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace ImageMigrator
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        public static void ConfigureServices(IServiceCollection services)
        {
            // setup Configuration

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();


            services.AddLogging();
            services.AddDbContext<SwiperContext>(options => options.UseSqlServer(configuration.GetConnectionString("DebugConnection")));

            services.AddOptions();
            services.Configure<HostConfig>(configuration.GetSection("Hosting"));
            services.Configure<StorageConfig>(configuration.GetSection("Storage"));


            services.AddTransient<ChallengeService, ChallengeService>();
            services.AddTransient<ProjectService, ProjectService>();
            services.AddTransient<UserService, UserService>();
            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<MigrateService, MigrateService>();
        }
    }
}
