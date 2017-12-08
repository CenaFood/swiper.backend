using ch.cena.swiper.backend.data.Models;
using ch.cena.swiper.backend.service.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ch.cena.swiper.backend.service.DTOs
{
    public class ChallengeDTO : IChallenge
    {

        public Guid ID { get; set; }
        public Guid ProjectID { get; set; }
        public string Type { get; set;  }
        public string Description { get; set; }
        public IImage Image { get; set; }
        public IEnumerable<string> Answers { get; set; }
    }
}
