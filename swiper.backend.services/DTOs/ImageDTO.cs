using ch.cena.swiper.backend.service.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ch.cena.swiper.backend.service.DTOs
{
    public class ImageDTO: IImage
    {
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string Url { get; set; }
    }
}
