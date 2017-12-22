using System;
using System.Collections.Generic;
using System.Text;
using ch.cena.swiper.backend.data;
using ch.cena.swiper.backend.service.Service;
using ch.cena.swiper.backend.services.Contracts;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ch.cena.swiper.backend.service.Contracts.Configuration;

namespace ImageMigrator
{
    public class SwiperMigrator
    {

        private readonly IProjectService projectService;
        private readonly IChallengeService challengeService;
        private readonly MigrateService migrateService;
        private readonly UserService userService;
        private readonly ILogger _logger;
        private readonly StorageConfig storageConfig;
        private readonly MigrationConfig migrationConfig;

        public SwiperMigrator(IProjectService projectService, 
                                IChallengeService challengeService, 
                                MigrateService migrateService, 
                                UserService userService,
                                ILogger<SwiperMigrator> logger,
                                IOptions<StorageConfig> storageConfig,
                                IOptions<MigrationConfig> migrationConfig) {
            this.projectService = projectService;
            this.challengeService = challengeService;
            this.migrateService = migrateService;
            this.userService = userService;
            this.storageConfig = storageConfig.Value;
            this.migrationConfig = migrationConfig.Value;
            _logger = logger;

        }

        public void Migrate()
        {

            // Do Migration
            userService.AddDummyUser();

            var project = projectService.GetProjectByName(migrationConfig.ProjectName);
            var challengeType = challengeService.GetChallengeTypeByName(migrationConfig.ChallengeTypeName);

            if (project == null && migrationConfig.CreateProject)
                project = projectService.CreateProject(migrationConfig.ProjectName);

            if (challengeType == null)
                challengeType = challengeService.CreateChallengeType(migrationConfig.ChallengeTypeName, migrationConfig.ChallengeQuestion, migrationConfig.ChallengeAnswers.AsEnumerable());

            var fileNames = Directory.EnumerateFiles(migrationConfig.PickupDirectory)
                .Select(i => Path.GetFileName(i))
                .ToList();

            for (int i = 0; i <= (fileNames.Count / 1000); i++)
            {
                _logger.LogInformation($"{i}000 to {i + 1}000: Start");
                var files = fileNames.Skip(i * 1000).Take(1000).ToList();
                var successfullFiles = migrateService.MigrateChalleges(project.ID, challengeType.ID, files);

                foreach (var successfullFile in successfullFiles)
                    File.Move(Path.Combine(migrationConfig.PickupDirectory, successfullFile), Path.Combine(storageConfig.ImageFolder, successfullFile));

                _logger.LogInformation($"{i}000 to {i + 1}000: Migrated");
            }
        }
    }
}
