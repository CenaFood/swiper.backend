using ch.cena.swiper.backend.data.Models;
using ch.cena.swiper.backend.service.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ch.cena.swiper.backend.services.Contracts
{
    public interface IProjectService
    {
        IEnumerable<IProject> GetProjects();
        IEnumerable<IProject> GetMyProjects();
        void InsertProject(IProject project);
        void CloseProject(IProject project);
    }
}
