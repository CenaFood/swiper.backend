using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ImageMigrator
{
    public class MigrationConfig
    {
        public bool Migrate { get; set; } = false;
        public bool CreateProject { get; set; } = false;
        public string ProjectName { get; set; }
        public string PickupDirectory { get; set; }

        public string ChallengeTypeName { get; set; }
        public string ChallengeQuestion { get; set; }
        public string[] ChallengeAnswers { get; set; }
    }
}
