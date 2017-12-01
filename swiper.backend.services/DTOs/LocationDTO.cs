using ch.cena.swiper.backend.service.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ch.cena.swiper.backend.service.DTOs
{
    class LocationDTO : ILocation
    {
        public LocationDTO(float latitude, float longitude){
            Latitude = latitude;
            Longitude = longitude;
        }

        public float Latitude { get; }

        public float Longitude { get; }
    }
}

