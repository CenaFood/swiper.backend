using ch.cena.swiper.backend.services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using ch.cena.swiper.backend.data.Models;

namespace ch.cena.swiper.backend.service.Service
{
    class ChallengeService : IChallengeService
    {
        public IEnumerable<Challenge> GetChallenges()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Challenge> GetChallengesFor(Project project)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Challenge> GetChallengesOf(ChallengeType type)
        {
            throw new NotImplementedException();
        }
    }
}
