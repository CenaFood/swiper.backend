using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text;

namespace ch.cena.swiper.backend.data.Models
{
    public class Annotation: BaseEntity
    {
        [Required]
        public Guid ChallengeID { get; set; }

        [Required]
        public Guid UserID { get; set; }

        [Required]
        [MaxLength(255)]
        public string AnswerText { get; set; }

        [Required]
        [Range(-90,90)]
        public float Latitude { get; set; }

        [Required]
        [Range(-180, 180)]
        public float Longitude { get; set; }

        [Required]
        public DateTimeOffset LocalTime { get; set; }

        public Challenge Challenge {get; set;}
        public User User { get; set; }
    }
}
