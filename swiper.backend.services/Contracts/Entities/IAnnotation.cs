using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ch.cena.swiper.backend.service.Contracts.Entities
{
    public interface IAnnotation
    {
        [Required]
        Guid ChallengeID { get; }

        [Required]
        Guid UserID { get; }

        [Required]
        [MaxLength(255)]
        string Answer { get; }

        [Required]
        [Range(-90, 90)]
        float Latitude { get; set; }

        [Required]
        [Range(-180, 180)]
        float Longitude { get; set; }

        [Required]
        DateTimeOffset LocalTime { get; set; }

    }
}
