using System;
using System.Collections.Generic;
using System.Text;

namespace ch.cena.swiper.backend.service.Contracts.Entities
{
    interface IProject
    {
        Guid ID { get; set; }
        string Description {get;set;}
    }
}
