using ch.cena.swiper.backend.data.Models;
using ch.cena.swiper.backend.service.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ch.cena.swiper.backend.service.Contracts.Service
{
    public interface IChallengeService
    {
        IEnumerable<IChallenge> GetChallenges(IUser user);
        IEnumerable<IChallenge> GetChallengesFor(IUser user, Guid projectID);
        IEnumerable<IChallenge> GetChallengesOf(IUser user, string type);
        ChallengeType CreateChallengeType(string name, string description, IEnumerable<string> answers);
        ChallengeType GetChallengeTypeByName(string name);
    }
}
