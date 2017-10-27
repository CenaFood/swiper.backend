using System;
using System.Collections.Generic;
using System.Text;

namespace ch.cena.swiper.backend.data.Models
{
    public abstract class BaseEntity
    {
        public Guid ID { get; set; }
    }
}
