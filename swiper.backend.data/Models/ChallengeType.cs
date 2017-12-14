using System;
using System.Collections.Generic;
using System.Text;

namespace ch.cena.swiper.backend.data.Models
{
    public class ChallengeType : BaseEntity
    {
        public string Name { get; set; }
        //TODO Not nullable
        public string Description { get; set; }

        public ICollection<Answer> Answers { get; set; }
        public ICollection<Challenge> Challenges { get; set; }
    }
}
