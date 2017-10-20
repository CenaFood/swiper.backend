using System;
using System.Collections.Generic;
using System.Text;

namespace ch.cena.swiper.backend.data.Models
{
    class ChallengeType
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Answer> Answers { get; set; }
        public ICollection<Challenge> Challenges { get; set; }
    }
}
