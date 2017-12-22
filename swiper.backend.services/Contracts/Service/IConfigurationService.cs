using System;
using System.Collections.Generic;
using System.Text;

namespace ch.cena.swiper.backend.service.Contracts
{
    interface IConfigurationService
    {
        Uri GetImageHostUrl(String filename);
        Uri GetImageHostRoot();

    }
}
