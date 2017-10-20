using ch.cena.swiper.backend.data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ch.cena.swiper.backend.services.Contracts
{
    interface IChallengeService
    {
        IEnumerable<Challenge> GetChallenges();
        IEnumerable<Challenge> GetChallengesFor(Project project);
        IEnumerable<Challenge> GetChallengesOf(ChallengeType type);
    }
}
