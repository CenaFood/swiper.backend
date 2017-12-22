using ch.cena.swiper.backend.data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ch.cena.swiper.backend.services.Contracts
{
    public interface IProjectService
    {
        IEnumerable<Project> GetProjects();
        IEnumerable<Project> GetMyProjects();
        void InsertProject(Project project);
        void CloseProject(Project project);
    }
}
