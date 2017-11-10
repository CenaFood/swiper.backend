using System;
using System.Collections.Generic;
using System.Text;
using ch.cena.swiper.backend.data.Models;
using ch.cena.swiper.backend.service.Contracts.Entities;

namespace ch.cena.swiper.backend.services.Contracts
{
    public interface IAnnotationService
    {
        void InsertAnnotation(IAnnotation annotation);
    }
}
