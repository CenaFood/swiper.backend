using System;
using System.Collections.Generic;
using System.Text;

namespace ch.cena.swiper.backend.data.Models
{
    public class Challenge : BaseEntity
    {
        public Guid ChallengeTypeID { get; set; }
        public Guid ProjectID { get; set; }
        public string FileName{ get; set; }

        public ChallengeType ChallengeType { get; set; }
        public Project Project { get; set; }
        public ICollection<Annotation> Annotations { get; set; }
    }
}
