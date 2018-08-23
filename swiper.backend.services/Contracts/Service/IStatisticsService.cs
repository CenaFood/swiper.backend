using ch.cena.swiper.backend.service.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ch.cena.swiper.backend.service.Contracts.Service
{
    public interface IStatisticsService
    {
        IEnumerable<IProjectStatistics> GetStatisticsForUser(IUser user);
    }
}
