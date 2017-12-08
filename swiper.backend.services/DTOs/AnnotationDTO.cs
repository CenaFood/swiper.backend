using ch.cena.swiper.backend.data.Models;
using ch.cena.swiper.backend.service.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ch.cena.swiper.backend.service.DTOs
{
    public class AnnotationDTO : IAnnotation
    {
        public Guid ChallengeID { get; set; }
        public Guid UserID { get; set; }
        public string Answer { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public DateTimeOffset LocalTime { get; set; }
    }
}
