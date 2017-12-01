using ch.cena.swiper.backend.data.Models;
using ch.cena.swiper.backend.service.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ch.cena.swiper.backend.service.DTOs
{
    public class ProjectDTO : Project, IProject
    {
        public ProjectDTO(Project project)
        {
            this.ID = project.ID;
            this.Description = project.Description;
            this.ExpiryDate = project.ExpiryDate;
            this.IssueDate = project.IssueDate;
        }
    }
}
