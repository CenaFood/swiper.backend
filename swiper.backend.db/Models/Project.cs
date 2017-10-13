using System;
using System.Collections.Generic;
using System.Text;

namespace ch.cena.swiper.backend.db.Models
{
    class Project
    {
        public Guid ID { get; set; }
        public string ProjectDescription { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime? ExpiryDate { get; set; }

        public ICollection<Challenge> Challenges { get; set; }
    }
}
