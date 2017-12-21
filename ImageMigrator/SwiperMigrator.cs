using System;
using System.Collections.Generic;
using System.Text;
using ch.cena.swiper.backend.data;
using ch.cena.swiper.backend.service.Service;
using ch.cena.swiper.backend.services.Contracts;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace ImageMigrator
{
    class SwiperMigrator
    {

        private readonly IProjectService projectService;
        private readonly IChallengeService challengeService;
        private readonly MigrateService migrateService;
        private readonly UserService userService;
        private readonly ILogger _logger;

        public SwiperMigrator(ProjectService projectService, 
                                IChallengeService challengeService, 
                                MigrateService migrateService, 
                                UserService userService,
                                ILogger<SwiperMigrator> logger) {
            this.projectService = projectService;
            this.challengeService = challengeService;
            this.migrateService = migrateService;
            this.userService = userService;
            _logger = logger;

        }

        public void Migrate()
        {

            // Do Migration
            var arguments = new MigrationArguments();

            arguments.CreateProject = true;
            arguments.ProjectName = "cena";
            arguments.ChallengeTypeName = "YesNo";

            arguments.PickupDirectory = @"C:\Users\phili\Desktop\Pickup"; // TODO Config
            arguments.ImagesDirectory = @"C:\Users\phili\Desktop\images"; // TODO Config

            userService.AddDummyUser();

            var project = projectService.GetProjectByName(arguments.ProjectName);
            var challengeType = challengeService.GetChallengeTypeByName(arguments.ChallengeTypeName);

            if (project == null && arguments.CreateProject)
                project = projectService.CreateProject(arguments.ProjectName);

            if (challengeType == null)
                challengeType = challengeService.CreateChallengeType(arguments.ChallengeTypeName, "Would you eat this here and now?", new List<string>() { "Yes", "No" });

            var fileNames = Directory.EnumerateFiles(arguments.PickupDirectory)
                .Select(i => Path.GetFileName(i))
                .ToList();

            for (int i = 0; i <= (fileNames.Count / 1000); i++)
            {
                _logger.LogInformation($"{i}000 to {i + 1}000: Start");
                var files = fileNames.Skip(i * 1000).Take(1000).ToList();
                var successfullFiles = migrateService.MigrateChalleges(project.ID, challengeType.ID, files);

                foreach (var successfullFile in successfullFiles)
                    File.Move(Path.Combine(arguments.PickupDirectory, successfullFile), Path.Combine(arguments.ImagesDirectory, successfullFile));

                _logger.LogInformation($"{i}000 to {i + 1}000: Migrated");
            }
        }
    }
}
