using ch.cena.swiper.backend.data;
using ch.cena.swiper.backend.data.Models;
using ch.cena.swiper.backend.service.Contracts.Service;
using ch.cena.swiper.backend.service.Contracts.Entities;
using ch.cena.swiper.backend.service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ch.cena.swiper.backend.service.Service
{
    public class UserService: IUserService
    {
        private readonly SwiperContext context;
        public UserService(SwiperContext swiperContext)
        {
            context = swiperContext;
        }

        public IUser GetUserFromUsername(string username) {
            var user = context.Users.Single(u => u.UserName == username);

            return new UserDTO {
                ID = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MailAddress = user.Email
            };
        }

        public void AddDummyUser()
        {
            if (!context.Users.Any(u => u.Id.Equals(Guid.Parse("6A1BA20A-8D25-4E71-8BD8-E6872FD53ADA"))))
            {
                context.Users.Add(new User
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@dum.my",
                    Id = Guid.Parse("6A1BA20A-8D25-4E71-8BD8-E6872FD53ADA")
                });
                context.SaveChanges();
            }
        }
    }
}
