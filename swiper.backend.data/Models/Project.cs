using System;
using System.Collections.Generic;
using System.Text;

namespace ch.cena.swiper.backend.data.Models
{
    public class Project : BaseEntity
    {
        public string Name { get; set; }
        public DateTimeOffset IssueDate { get; set; }
        public DateTimeOffset? ExpiryDate { get; set; }

        public ICollection<Challenge> Challenges { get; set; }
    }
}
