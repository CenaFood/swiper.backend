using ch.cena.swiper.backend.services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using ch.cena.swiper.backend.data.Models;
using ch.cena.swiper.backend.service.Contracts.Entities;
using ch.cena.swiper.backend.data;
using System.Linq;
using ch.cena.swiper.backend.service.DTOs;
using AutoMapper.QueryableExtensions;
using ch.cena.swiper.backend.service.Contracts.Service;

namespace ch.cena.swiper.backend.service.Service
{
    public class ChallengeService : IChallengeService
    {

        private readonly SwiperContext context;
        private readonly IImageService imgService;
        public ChallengeService(SwiperContext swiperContext, IImageService imageService)
        {
            context = swiperContext;
            imgService = imageService;
        }

        public IEnumerable<IChallenge> GetChallenges(IUser user)
        {
            // TODO: Check performance
            var challenges = context.Challenges.Where(c => !c.Annotations.Any(a => a.UserID == user.ID))
                              .OrderByRandom()
                              .Take(20)
                              .Select(c =>
                                new ChallengeDTO {
                                    ID = c.ID,
                                    Answers = c.ChallengeType.Answers.Select(t=> t.Text).ToList(),
                                    Description = c.ChallengeType.Description,
                                    ProjectID = c.ProjectID,
                                    ChallengeType = c.ChallengeType.Name,
                                    Image = imgService.GetImageByFilename(c.FileName)
                                })
                              .ToList();

            return challenges;

        }

        public IEnumerable<IChallenge> GetChallengesFor(IUser user, Guid projectID)
        {
            return context.Challenges.Where(c => !c.Annotations.Any(a => a.UserID == user.ID))
                            .Where(c => c.ProjectID == projectID)
                            .OrderByRandom()
                            .Take(20)
                            .ProjectTo<ChallengeDTO>()
                            .ToList();
        }

        public IEnumerable<IChallenge> GetChallengesOf(IUser user, string type)
        {
            return context.Challenges.Where(c => !c.Annotations.Any(a => a.UserID == user.ID))
                              .Where(c => c.ChallengeType.Description == type)
                              .OrderByRandom()
                              .Take(20)
                              .ProjectTo<ChallengeDTO>()
                              .ToList();
        }

        public ChallengeType GetChallengeTypeByName(string name)
        {
            return context.ChallengeTypes.FirstOrDefault(i => i.Name.ToLower() == name.ToLower().Trim());
        }

        public ChallengeType CreateChallengeType(string name, List<string> answers)
        {
            var challengeType = new ChallengeType()
            {
                Answers = answers.Select(i => new Answer() { Text = i}).ToList(),
                Name = name
            };

            context.ChallengeTypes.Add(challengeType);
            context.SaveChanges();

            return challengeType;
        }
    }
}
