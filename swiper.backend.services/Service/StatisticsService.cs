using ch.cena.swiper.backend.data;
using ch.cena.swiper.backend.service.Contracts.Entities;
using ch.cena.swiper.backend.service.Contracts.Service;
using ch.cena.swiper.backend.service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ch.cena.swiper.backend.service.Service
{
    public class StatisticsService: IStatisticsService
    {
        private readonly SwiperContext context;
        public StatisticsService(SwiperContext swiperContext)
        {
            context = swiperContext;
        }



        public IEnumerable<IProjectStatistics> GetProjectStatistics()
        {
            throw new NotImplementedException();
        }

        public IProjectStatistics GetProjectStatisticsForProject(string ProjectName)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<IProjectStatistics> GetStatisticsForUser(IUser user)
        {
            var result = new List<ProjectStatisticsDTO>();

            var contributedProjects = 
                context.Annotations
                .Where(a => a.UserID == user.ID)
                .Select(a => a.Challenge.Project)
                .Distinct();

            foreach (var project in contributedProjects)
            {
                result.Add(new ProjectStatisticsDTO()
                {
                    ProjectName = project.Name,
                    LabelCount = context.Annotations
                                        .Where(a => a.Challenge.ProjectID == project.ID)
                                        .Count(),
                    PersonalLabelsCount = context.Annotations
                                        .Where(a => a.UserID == user.ID)
                                        .Where(a => a.Challenge.ProjectID == project.ID)
                                        .Count()
                });
            }

            return result;
        }
    }
}
