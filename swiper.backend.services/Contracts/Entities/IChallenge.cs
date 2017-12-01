using System;
using System.Collections.Generic;
using System.Text;

namespace ch.cena.swiper.backend.service.Contracts.Entities
{
    public interface IChallenge
    {
        Guid ID { get; }
        string Type { get; }
        string Description { get; }
        IImage Image { get; }
        IEnumerable<string> Answers { get; }

    }
}
