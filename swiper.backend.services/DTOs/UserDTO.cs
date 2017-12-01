using ch.cena.swiper.backend.data.Models;
using ch.cena.swiper.backend.service.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ch.cena.swiper.backend.service.DTOs
{
    public class UserDTO : User, IUser
    {
        public string Name => $"{this.FirstName} {this.LastName}";


        //TODO: Remove Dummy user
        public static UserDTO GetDummy()
        {
            return new UserDTO
            {
                FirstName = "John",
                LastName = "Doe",
                MailAddress = "john.doe@dum.my",
                ID = Guid.Parse("{ 6A1BA20A - 8D25 - 4E71 - 8BD8 - E6872FD53ADA }")
            };
        }
    }    
}
