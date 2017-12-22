using ch.cena.swiper.backend.services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using ch.cena.swiper.backend.data.Models;
using System.Linq;
using ch.cena.swiper.backend.data;

namespace ch.cena.swiper.backend.service.Service
{
    public class AnnotationService : IAnnotationService
    {

        private readonly SwiperContext context;
        public AnnotationService(SwiperContext swiperContext)
        {
            context = swiperContext;
        }


        public Annotation GetAnnotation(Guid id)
        {
            return context.Annotations.Find(id);
        }

        public IEnumerable<Annotation> GetAnnotations(Project project)
        {
            return context.Annotations
                .Where(a => a.Challenge.ProjectID.Equals(project.ID));
        }

        public void InsertAnnotation(Annotation annotation)
        {
            context.Annotations.Add(annotation);
            context.SaveChangesAsync();
        }
    }
}
