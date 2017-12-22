using System;
using System.Collections.Generic;
using System.Text;


namespace ch.cena.swiper.backend.service.Contracts.Entities
{
    public interface ILocation
    {
        float Latitude { get; }
        float Longitude { get; }
    }
}
