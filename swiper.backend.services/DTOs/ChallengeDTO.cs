using ch.cena.swiper.backend.data.Models;
using ch.cena.swiper.backend.service.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ch.cena.swiper.backend.service.DTOs
{
    public class ChallengeDTO : Challenge, IChallenge
    {
        public string Type => this.ChallengeType.Name;

        public string Description => this.ChallengeType.Description;

        public IImage Image => throw new NotImplementedException();

        public IEnumerable<string> Answers => this.ChallengeType.Answers.Select(a => a.Descripton);
    }
}
