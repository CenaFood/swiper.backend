using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ch.cena.swiper.backend.data.Models
{
    public class ChallengeType : BaseEntity
    {
        [Required]
        [MaxLength(32)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

        public ICollection<Answer> Answers { get; set; }
        public ICollection<Challenge> Challenges { get; set; }
    }
}
