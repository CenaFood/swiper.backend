using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text;

namespace ch.cena.swiper.backend.data.Models
{
    public class Project : BaseEntity
    {
        [Required]
        [MaxLength(64)]
        public string Name { get; set; }

        [Required]
        public DateTimeOffset IssueDate { get; set; }
        public DateTimeOffset? ExpiryDate { get; set; }

        public ICollection<Challenge> Challenges { get; set; }
    }
}
