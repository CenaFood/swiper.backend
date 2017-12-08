using System;
using System.Collections.Generic;
using System.Text;

namespace ch.cena.swiper.backend.service.Contracts.Entities
{
    public interface IImage
    {
        string FileName { get; }
        string FileExtension { get; }
        int Height { get; }
        int Width { get; }
        string Url { get; }
    }
}
