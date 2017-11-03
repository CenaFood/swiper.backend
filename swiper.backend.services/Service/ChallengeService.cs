using ch.cena.swiper.backend.services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using ch.cena.swiper.backend.data.Models;
using ch.cena.swiper.backend.service.Contracts.Entities;

namespace ch.cena.swiper.backend.service.Service
{
    public class ChallengeService : IChallengeService
    {
        public IEnumerable<IChallenge> GetChallenges(IUser user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IChallenge> GetChallengesFor(IUser user, Guid projectID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IChallenge> GetChallengesOf(IUser user, string type)
        {
            throw new NotImplementedException();
        }
    }
}
