using ch.cena.swiper.backend.data.Models;
using ch.cena.swiper.backend.service.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ch.cena.swiper.backend.service.DTOs
{
    public class AnnotationDTO : Annotation, IAnnotation
    {
        public ILocation Location => new LocationDTO(Latitude, Longitude);
    }
}
