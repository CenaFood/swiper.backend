using System;
using System.Collections.Generic;
using System.Text;

namespace ch.cena.swiper.backend.data.Models
{
    public class Project : BaseEntity
    {
        public string Description { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime? ExpiryDate { get; set; }

        public ICollection<Challenge> Challenges { get; set; }
    }
}
