using System;
using System.Collections.Generic;
using System.Text;

namespace ch.cena.swiper.backend.data.Models
{
    public class Answer : BaseEntity
    {
        public string Descripton { get; set; }

        public ICollection<Annotation> Annotations { get; set; }
        public ICollection<ChallengeType> ChallengeTypes;
    }
}
