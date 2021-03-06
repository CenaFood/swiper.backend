﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ch.cena.swiper.backend.service.Contracts.Entities
{
    public interface IChallenge
    {
        Guid ID { get; }
        Guid ProjectID { get; }
        string ChallengeType { get; }
        string Description { get; }
        IImage Image { get; }
        IEnumerable<string> Answers { get; }

    }
}
