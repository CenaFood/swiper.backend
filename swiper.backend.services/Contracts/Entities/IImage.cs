using System;
using System.Collections.Generic;
using System.Text;

namespace ch.cena.swiper.backend.service.Contracts.Entities
{
    interface IImage
    {
        string ID { get; set; }
        string FileName { get; set; }
        string Extension { get; set; }
        int Height { get; set; }
        int Width { get; set; }
        string Url { get; set; }
    }
}
