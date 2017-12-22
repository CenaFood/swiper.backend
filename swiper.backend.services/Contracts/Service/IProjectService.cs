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
        IEnumerable<IProject> GetMyProjects(IUser user);
        void InsertProject(IUser user, IProject project);
        void CloseProject(IUser user, IProject project);
        Project CreateProject(string projectName);
        Project GetProjectByName(string projectName);
    }
}
