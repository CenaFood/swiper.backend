using ch.cena.swiper.backend.services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using ch.cena.swiper.backend.data.Models;
using ch.cena.swiper.backend.repo.Contracts;

namespace ch.cena.swiper.backend.service.Service
{
    class AnnotationService : IAnnotationService
    {

        private IRepository<Annotation> annotationRepository;
        private IRepository<Project> projectRepository;
        private IRepository<User> userRepository;

        public AnnotationService(IRepository<Annotation> annotationRepository,
                                 IRepository<User> userRepository,
                                 IRepository<Project> projectRepository)
        {
            this.annotationRepository = annotationRepository;
            this.userRepository = userRepository;
            this.projectRepository = projectRepository;
        }


        public Annotation GetAnnotation(Guid id)
        {
            return annotationRepository.Get(id);
        }

        public IEnumerable<Annotation> GetAnnotations(Project project)
        {
            throw new NotImplementedException();
        }

        public void InsertAnnotation(Annotation annotation)
        {
            annotationRepository.Insert(annotation);
        }
    }
}
