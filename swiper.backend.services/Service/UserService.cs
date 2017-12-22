using ch.cena.swiper.backend.data;
using ch.cena.swiper.backend.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ch.cena.swiper.backend.service.Service
{
    public class UserService
    {
        private readonly SwiperContext context;
        public UserService(SwiperContext swiperContext)
        {
            context = swiperContext;
        }

        public void AddDummyUser()
        {
            if (!context.Users.Any(u => u.ID.Equals(Guid.Parse("6A1BA20A-8D25-4E71-8BD8-E6872FD53ADA"))))
            {
                context.Users.Add(new User
                {
                    FirstName = "John",
                    LastName = "Doe",
                    MailAddress = "john.doe@dum.my",
                    ID = Guid.Parse("6A1BA20A-8D25-4E71-8BD8-E6872FD53ADA")
                });
                context.SaveChanges();
            }
        }
    }
}
