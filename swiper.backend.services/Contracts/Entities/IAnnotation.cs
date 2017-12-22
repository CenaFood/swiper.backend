using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ch.cena.swiper.backend.service.Contracts.Entities
{
    public interface IAnnotation
    {
        Guid ChallengeID { get; }
        Guid UserID { get; }
        string Answer { get; }
        float Latitude { get; set; }
        float Longitude { get; set; }
        DateTimeOffset LocalTime { get; set; }
    }
}
