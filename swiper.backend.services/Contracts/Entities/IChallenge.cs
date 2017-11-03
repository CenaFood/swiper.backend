using System;
using System.Collections.Generic;
using System.Text;

namespace ch.cena.swiper.backend.service.Contracts.Entities
{
    interface IChallenge
    {
        Guid ID { get; set; }
        string Type { get; set; }
        string Description { get; set; }
        IProject Project { get; set; }
        IImage Image { get; set; }
        IEnumerable<string> Answers { get; set; }

    }
}
