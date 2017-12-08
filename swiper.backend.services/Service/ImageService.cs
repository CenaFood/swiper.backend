using ch.cena.swiper.backend.data;
using ch.cena.swiper.backend.service.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using ch.cena.swiper.backend.service.Contracts.Service;
using ch.cena.swiper.backend.service.Contracts.Entities;
using Microsoft.Extensions.Options;
using ch.cena.swiper.backend.service.Contracts.Configuration;

namespace ch.cena.swiper.backend.service.Service
{
    public class ImageService: IImageService
    {
        private readonly SwiperContext context;
        private readonly IOptions<HostConfig> hostConfig;

        public ImageService(SwiperContext swiperContext, IOptions<HostConfig> hostConfig)
        {
            context = swiperContext;
            this.hostConfig = hostConfig;
        }

        public IImage GetImageByChallengeId(Guid challengeID)
        {
            string filename = context.Challenges.FirstOrDefault(c => c.ID == challengeID)?.FileName;
            return GetImageByFilename(filename);
        }

        public IImage GetImageByFilename(string filename)
        {
            if (String.IsNullOrEmpty(filename)) return null;
            // TODO Get actual configuration and dimetions.
            return new ImageDTO()
            {
                FileName = filename,
                FileExtension = Path.GetExtension(filename),
                Height = 512,
                Width = 512,
                //TODO: Make this more save
                Url = hostConfig.Value.HostingUri + hostConfig.Value.ImageHostFolder + filename
            };            
        }

    }
}
