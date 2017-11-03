using System;
using System.Collections.Generic;
using System.Text;

namespace ch.cena.swiper.backend.service.Contracts.Entities
{
    interface IAnnotation
    {
        Guid ChallengeID { get; set; }
        Guid UserID { get; set; }
        string Answer { get; set; }
    }
}
