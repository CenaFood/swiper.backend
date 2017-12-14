using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ImageMigrator
{
    class MigrationArguments
    {
        public bool CreateProject { get; set; }
        public string ProjectName { get; set; }
        public string PickupDirectory { get; set; }
        public string ImagesDirectory { get; set; }

        public string ChallengeTypeName { get; set; }


        public bool IsValid()
        {
            return !String.IsNullOrEmpty(ProjectName)
                && !String.IsNullOrEmpty(ImagesDirectory)
                && Directory.Exists(ImagesDirectory);
        }
        
        public IEnumerable<string> GetErrors()
        {
            var errors = new List<string>();
            if (String.IsNullOrEmpty(ProjectName)) errors.Add("No project name specified.");

            if (String.IsNullOrEmpty(PickupDirectory)) errors.Add("No pick up directory specified.");
            else if (!Directory.Exists(PickupDirectory)) errors.Add("Pick up directory does not exist.");

            if (String.IsNullOrEmpty(ImagesDirectory)) errors.Add("No images directory specified.");
            else if (!Directory.Exists(ImagesDirectory)) errors.Add("Images directory does not exist.");

            return errors;
        }

        public static bool TryParse(string[] args, out MigrationArguments migrationArguments)
        {
            int index = 0;
            migrationArguments = new MigrationArguments();
            try
            {
                if (args[index] == "-c")
                {
                    migrationArguments.CreateProject = true;
                    index++;
                }

                migrationArguments.ProjectName = args[index++];
                migrationArguments.ImagesDirectory = args[index++];
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
            return migrationArguments.IsValid();
        }
    }
}
