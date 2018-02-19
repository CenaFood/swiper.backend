using ch.cena.swiper.backend.service.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ch.cena.swiper.backend.service.Contracts.Service
{
    public interface IUserService
    {
        IUser GetUserFromEmail(string email);
    }
}
