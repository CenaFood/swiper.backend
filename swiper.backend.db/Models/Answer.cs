using System;
using System.Collections.Generic;
using System.Text;

namespace ch.cena.swiper.backend.db.Models
{
    class Answer
    {
        public Guid ID { get; set; }
        public string Descripton { get; set; }

        public ICollection<Annotation> Annotations { get; set; }
        public ICollection<ChallengeType> ChallengeTypes;
    }
}
