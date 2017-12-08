using System;
using System.Collections.Generic;
using System.Text;

namespace ch.cena.swiper.backend.service.Contracts.Service
{
    interface IConfigurationService
    {
        Uri GetImageHostUrl(String filename);
        Uri GetImageHostRoot();

    }
}
