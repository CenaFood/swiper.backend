using ch.cena.swiper.backend.data;
using ch.cena.swiper.backend.service.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ch.cena.swiper.backend.service.Service
{
    public class ImageService
    {
        private readonly SwiperContext context;
        public ImageService(SwiperContext swiperContext)
        {
            context = swiperContext;
        }

        public ImageDTO GetImageByChallengeId(Guid challengeID)
        {
            string filename = context.Challenges.FirstOrDefault(c => c.ID == challengeID)?.FileName;
            return GetImageByFilename(filename);
        }

        public ImageDTO GetImageByFilename(string filename)
        {
            if (String.IsNullOrEmpty(filename)) return null;
            return new ImageDTO()
            {
                // TODO: Fill image DTO correctly
            };            
        }

    }
}
