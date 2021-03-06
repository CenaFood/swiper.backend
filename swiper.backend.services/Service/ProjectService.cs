﻿using System;
using System.Collections.Generic;
using System.Text;
using ch.cena.swiper.backend.data.Models;
using ch.cena.swiper.backend.service.Contracts.Entities;
using ch.cena.swiper.backend.data;
using System.Linq;
using ch.cena.swiper.backend.service.Contracts.Service;

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

        public Project GetProjectByName(string name)
        {
            return context.Projects.FirstOrDefault(i => i.ExpiryDate > DateTime.Now && i.Name.ToLower() == name.ToLower().Trim());
        }

        public Project CreateProject(string name)
        {
            var project = new Project()
            {
                Name = name,
                ExpiryDate = DateTime.Now.AddYears(2),
                IssueDate = DateTime.Now
            };

            context.Projects.Add(project);
            context.SaveChanges();

            return project;
        }
    }
}
