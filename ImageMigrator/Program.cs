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


            // setup our DI
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // configure console logging
            serviceProvider.GetService<ILoggerFactory>();


            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();
            logger.LogDebug("Starting application");


            // Do Migration
            var arguments = new MigrationArguments();

            arguments.CreateProject = true;
            arguments.ProjectName = "cena";
            arguments.ChallengeTypeName = "YesNo";

            arguments.PickupDirectory = @"C:\Users\phili\Desktop\Pickup"; // TODO Config
            arguments.ImagesDirectory = @"C:\Users\phili\Desktop\images"; // TODO Config

            var projectService = serviceProvider.GetService<ProjectService>();
            var challengeService = serviceProvider.GetService<ChallengeService>();
            var migrateService = serviceProvider.GetService<MigrateService>();

            var project = projectService.GetProjectByName(arguments.ProjectName);
            var challengeType = challengeService.GetChallengeTypeByName(arguments.ChallengeTypeName);

            if (project == null && arguments.CreateProject)
                project = projectService.CreateProject(arguments.ProjectName);

            if (challengeType == null)
                challengeType = challengeService.CreateChallengeType(arguments.ChallengeTypeName, new List<string>() { "Yes", "No" });

            var fileNames = Directory.EnumerateFiles(arguments.PickupDirectory)
                .Select(i => Path.GetFileName(i))
                .ToList();

            for (int i = 0; i <= (fileNames.Count / 1000); i++)
            {
                logger.LogInformation($"{i}000 to {i + 1}000: Start");
                var files = fileNames.Skip(i * 1000).Take(1000).ToList();
                var successfullFiles = migrateService.MigrateChalleges(project.ID, challengeType.ID, files);

                foreach (var successfullFile in successfullFiles)
                    File.Move(Path.Combine(arguments.PickupDirectory, successfullFile), Path.Combine(arguments.ImagesDirectory, successfullFile));

                logger.LogInformation($"{i}000 to {i + 1}000: Migrated");
            }
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
            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<MigrateService, MigrateService>();
        }
    }
}
