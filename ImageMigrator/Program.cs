using ch.cena.swiper.backend.data;
using ch.cena.swiper.backend.data.Models;
using ch.cena.swiper.backend.service.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
            var builder = new ConfigurationBuilder()
       .SetBasePath(Directory.GetCurrentDirectory())
       .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();
            MigrationArguments arguments;

            string projectName = "cena"; // TODO Config
            string challengeTypeName = "cena"; // TODO Config
            string mainPath = @"C:\Users\phili\Desktop\Pickup"; // TODO Config
            string donePath = @"C:\Users\phili\Desktop\images"; // TODO Config
            if (MigrationArguments.TryParse(args, out arguments) || true)
            {
                var optionsBuilder = new DbContextOptionsBuilder<SwiperContext>();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DebugConnection"));

                using (var context = new SwiperContext(optionsBuilder.Options))
                {
                    var projectService = new ProjectService(context);
                    var challengeService = new ChallengeService(context, new ImageService(context));
                    var migrateService = new MigrateService(context);

                    var project = projectService.GetProjectByName(projectName);
                    var challengeType = challengeService.GetChallengeTypeByName(challengeTypeName);

                    if (project == null)
                        project = projectService.CreateProject(projectName);

                    if(challengeType == null)
                        challengeType = challengeService.CreateChallengeType(challengeTypeName, new List<string>() { "Yes", "No" });

                    var fileNames = Directory.EnumerateFiles(mainPath)
                        .Select(i => Path.GetFileName(i))
                        .ToList();

                    for (int i = 0; i <= (fileNames.Count / 1000); i++)
                    {
                        var files = fileNames.Skip(i * 1000).Take(1000).ToList();
                        var successfullFiles = migrateService.MigrateChalleges(project.ID, challengeType.ID, files);

                        foreach (var successfullFile in successfullFiles)
                            File.Move(Path.Combine(mainPath, successfullFile), Path.Combine(donePath, successfullFile));
                    }

                    //SwiperMigrator.Migrate(new SwiperContext(), arguments); }
                }
            }
            else
            {
                Console.WriteLine("Argument could not be parsed:");
                foreach (string error in arguments.GetErrors())
                {
                    Console.WriteLine(error);
                }
            }
        }
    }
}
