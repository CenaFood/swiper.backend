using System;
using System.Collections.Generic;
using System.Text;

namespace ch.cena.swiper.backend.service.Contracts.Entities
{
    public interface IProjectStatistics
    {
        string ProjectName { get; }
        int LabelCount { get; }
        int PersonalLabelsCount { get; }
    }
}
