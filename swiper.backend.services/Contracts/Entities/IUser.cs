using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ch.cena.swiper.backend.service.Contracts.Entities
{
    public interface IUser
    {
        [Required]
        Guid ID { get; }
        [Required]
        string Name { get; }
    }
}
