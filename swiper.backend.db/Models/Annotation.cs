using System;
using System.Collections.Generic;
using System.Text;

namespace ch.cena.swiper.backend.db.Models
{
    class Annotation
    {
        public Guid ID { get; set; }
        public Guid AnswerID { get; set; }
        public Guid ChallengeID { get; set; }
        public Guid UserID { get; set; }
        public string Payload { get; set; }

        public Answer Answer { get; set; }
        public Challenge Challenge {get; set;}
        public User User { get; set; }
    }
}
