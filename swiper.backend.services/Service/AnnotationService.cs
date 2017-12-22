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

        /// <summary>
        /// Inserts an IAnnotation into the Database.
        /// </summary>
        /// <param name="annotation"></param>
        public void InsertAnnotation(IAnnotation annotation)
        {
            Annotation newItem = new Annotation()
            {
                ChallengeID = annotation.ChallengeID,
                AnswerText = annotation.Answer,
                UserID = annotation.UserID,
                Latitude = annotation.Latitude,
                Longitude = annotation.Longitude,
                LocalTime = annotation.LocalTime
            };
            context.Annotations.Add(newItem);
            context.SaveChanges();
        }
    }
}
