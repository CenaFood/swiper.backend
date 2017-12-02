using ch.cena.swiper.backend.services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using ch.cena.swiper.backend.data.Models;
using ch.cena.swiper.backend.service.Contracts.Entities;
using ch.cena.swiper.backend.data;
using System.Linq;
using ch.cena.swiper.backend.service.DTOs;

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
            // TODO: Check performance
            return context.Challenges.Where(c => !c.Annotations.Any(a => a.UserID == user.ID))
                              .OrderByRandom()
                              .Take(20)
                              .ToList()
                              .Cast<ChallengeDTO>();
        }

        public IEnumerable<IChallenge> GetChallengesFor(IUser user, Guid projectID)
        {
            return context.Challenges.Where(c => !c.Annotations.Any(a => a.UserID == user.ID))
                            .Where(c => c.ProjectID == projectID)
                            .OrderByRandom()
                            .Take(20)
                            .ToList()
                            .Cast<ChallengeDTO>();
        }

        public IEnumerable<IChallenge> GetChallengesOf(IUser user, string type)
        {
            return context.Challenges.Where(c => !c.Annotations.Any(a => a.UserID == user.ID))
                              .Where(c => c.ChallengeType.Description == type)
                              .OrderByRandom()
                              .Take(20)
                              .ToList()
                              .Cast<ChallengeDTO>();
        }
        public ChallengeType GetChallengeTypeByName(string name)
        {
            return context.ChallengeTypes.FirstOrDefault(i => i.Name.ToLower() == name.ToLower().Trim());
        }
        public ChallengeType CreateChallengeType(string name, List<string> answers)
        {
            var challengeType = new ChallengeType()
            {
                Answers = answers.Select(i => new Answer() { Descripton = i}).ToList(),
                Name = name
            };

            context.ChallengeTypes.Add(challengeType);
            context.SaveChanges();

            return challengeType;
        }
    }
}
