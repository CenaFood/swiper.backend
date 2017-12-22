using System;
using System.Collections.Generic;
using System.Text;

namespace ch.cena.swiper.backend.service.Contracts.Entities
{
    public interface IProject
    {
        Guid ID { get;  }
        string Name { get; }
        DateTimeOffset IssueDate { get; }
        DateTimeOffset? ExpiryDate { get; }
    }
}
