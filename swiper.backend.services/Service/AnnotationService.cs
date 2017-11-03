using ch.cena.swiper.backend.services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using ch.cena.swiper.backend.data.Models;
using System.Linq;
using ch.cena.swiper.backend.data;
using ch.cena.swiper.backend.service.Contracts.Entities;

namespace ch.cena.swiper.backend.service.Service
{
    public class AnnotationService : IAnnotationService
    {

        private readonly SwiperContext context;
        public AnnotationService(SwiperContext swiperContext)
        {
            context = swiperContext;
        }

        public void InsertAnnotation(IAnnotation annotation)
        {
            throw new NotImplementedException();
        }
    }
}
