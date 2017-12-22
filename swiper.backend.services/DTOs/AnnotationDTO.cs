using ch.cena.swiper.backend.data.Models;
using ch.cena.swiper.backend.service.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ch.cena.swiper.backend.service.DTOs
{
    public class AnnotationDTO : IAnnotation
    {
        [Required]
        public Guid ChallengeID { get; set; }

        [Required]
        public Guid UserID { get; set; }

        [Required]
        [MaxLength(255)]
        public string Answer { get; set; }

        [Required]
        [Range(-90, 90)]
        public float Latitude { get; set; }

        [Required]
        [Range(-180, 180)]
        public float Longitude { get; set; }

        [Required]
        public DateTimeOffset LocalTime { get; set; }
    }
}
