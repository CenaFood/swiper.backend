using System;
using System.Collections.Generic;
using System.Text;

namespace ch.cena.swiper.backend.service.Contracts.Entities
{
    public interface IAnnotation
    {
        Guid ChallengeID { get; }
        Guid UserID { get; }
        string Answer { get; }
    }
}
