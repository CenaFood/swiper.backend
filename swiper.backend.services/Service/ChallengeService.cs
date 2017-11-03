using ch.cena.swiper.backend.services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using ch.cena.swiper.backend.data.Models;
using ch.cena.swiper.backend.service.Contracts.Entities;
using ch.cena.swiper.backend.data;
using System.Linq;

namespace ch.cena.swiper.backend.service.Service
{
    public class ChallengeService : IChallengeService
    {

        private readonly SwiperContext context;
        public ChallengeService(SwiperContext swiperContext)
        {
            context = swiperContext;
        }

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
