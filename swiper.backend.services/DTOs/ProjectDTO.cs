using ch.cena.swiper.backend.data.Models;
using ch.cena.swiper.backend.service.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ch.cena.swiper.backend.service.DTOs
{
    public class ProjectDTO : IProject
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTimeOffset IssueDate { get; set; }
        public DateTimeOffset? ExpiryDate { get; set; }

    }
}
