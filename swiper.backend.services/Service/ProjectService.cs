using ch.cena.swiper.backend.services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using ch.cena.swiper.backend.data.Models;
using ch.cena.swiper.backend.service.Contracts.Entities;
using ch.cena.swiper.backend.data;

namespace ch.cena.swiper.backend.service.Service
{
    public class ProjectService : IProjectService
    {
        private readonly SwiperContext context;
        public ProjectService(SwiperContext swiperContext)
        {
            context = swiperContext;
        }

        public void CloseProject(IUser user, IProject project)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IProject> GetMyProjects(IUser user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IProject> GetProjects()
        {
            throw new NotImplementedException();
        }

        public void InsertProject(IUser user, IProject project)
        {
            throw new NotImplementedException();
        }
    }
}
