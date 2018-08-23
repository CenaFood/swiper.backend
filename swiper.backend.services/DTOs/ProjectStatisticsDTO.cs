using ch.cena.swiper.backend.service.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ch.cena.swiper.backend.service.DTOs
{
    class ProjectStatisticsDTO: IProjectStatistics
    {
        public string ProjectName { get; set; }
        public int LabelCount { get; set; }
        public int PersonalLabelsCount { get; set; }
    }
}
