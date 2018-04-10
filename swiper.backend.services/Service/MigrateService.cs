using ch.cena.swiper.backend.data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ch.cena.swiper.backend.service.Service
{
    public class MigrateService
    {
        private readonly SwiperContext context;
        public MigrateService(SwiperContext swiperContext)
        {
            context = swiperContext;
        }

        public List<string> RemoveExistingFiles(List<string> fileNames)
        {
            var filesInDb = context.Challenges.Where(i => fileNames.Contains(i.FileName)).Select(i => i.FileName);
            return fileNames.Where(i => !filesInDb.Contains(i)).ToList();
        }

        public List<string> MigrateChalleges(Guid projectId, Guid challengeTypeId, List<string> fileNames)
        {
            var returnList = new List<string>();
            fileNames = RemoveExistingFiles(fileNames);

            foreach (var fileName in fileNames)
            {
                bool success = MigrateChallege(projectId, challengeTypeId, fileName);
                if (success)
                    returnList.Add(fileName);
            }

            return returnList;
        }

        private bool MigrateChallege(Guid projectId, Guid challengeTypeId, string fileName)
        {
            try
            {
                context.Challenges.Add(new data.Models.Challenge()
                {
                    Annotations = null,
                    ChallengeTypeID = challengeTypeId,
                    FileName = fileName,
                    ID = new Guid(),
                    ProjectID = projectId
                });
                context.SaveChanges();

                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
