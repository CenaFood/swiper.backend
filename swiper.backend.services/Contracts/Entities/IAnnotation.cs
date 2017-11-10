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
        string Answer { get; }
    }
}
