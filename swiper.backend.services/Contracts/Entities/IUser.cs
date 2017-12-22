using System;
using System.Collections.Generic;
using System.Text;

namespace ch.cena.swiper.backend.service.Contracts.Entities
{
    public interface IUser
    {
        Guid ID { get; }
        string Name { get; }
        string FirstName { get; }        
        string LastName { get;  }
        string MailAddress { get;  }
    }
}
