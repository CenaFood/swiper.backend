using System;
using System.Collections.Generic;
using System.Text;

namespace ch.cena.swiper.backend.data.Models
{
    public class Annotation: BaseEntity
    {
        public Guid ChallengeID { get; set; }
        public Guid UserID { get; set; }
        public string Answer { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public DateTime LocalTime { get; set; }

        public Challenge Challenge {get; set;}
        public User User { get; set; }
    }
}
