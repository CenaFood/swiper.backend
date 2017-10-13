using System;
using System.Collections.Generic;
using System.Text;

namespace ch.cena.swiper.backend.db.Models
{
    class Challenge
    {
        public Guid ID { get; set; }
        public Guid ChallengeTypeID { get; set; }
        public Guid ProjectID { get; set; }
        public Object Payload { get; set; }

        public ChallengeType ChallengeType { get; set; }
        public Project Project { get; set; }
        public ICollection<Annotation> Annotations { get; set; }
    }
}
