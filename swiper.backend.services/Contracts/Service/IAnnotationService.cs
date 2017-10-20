using System;
using System.Collections.Generic;
using System.Text;
using ch.cena.swiper.backend.data.Models;

namespace ch.cena.swiper.backend.services.Contracts
{
    interface IAnnotationService
    {
        IEnumerable<Annotation> GetAnnotations(Project project);
        Annotation GetAnnotation(Guid id);
        void InsertAnnotation(Annotation annotation);
    }
}
