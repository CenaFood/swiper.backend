using ch.cena.swiper.backend.data;
using ch.cena.swiper.backend.service.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ch.cena.swiper.backend.service.Service
{
    public class ExportService
    {
        private readonly SwiperContext context;
        public ExportService(SwiperContext swiperContext)
        {
            context = swiperContext;
        }

        
        public ICollection<IAnnotationExportDTO> ExportForProject(String project)
        {
            throw new NotImplementedException();
        }
    }
}
