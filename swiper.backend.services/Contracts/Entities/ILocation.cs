using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace ch.cena.swiper.backend.service.Contracts.Entities
{
    public interface ILocation
    {
        [Required]
        float Latitude { get; }
        [Required]
        float Longitude { get; }
    }
}
