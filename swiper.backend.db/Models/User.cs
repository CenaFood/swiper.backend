using System;
using System.Collections.Generic;
using System.Text;

namespace ch.cena.swiper.backend.db.Models
{
    class User
    {
        public Guid ID { get; set; };
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MailAddress { get; set; }

        public ICollection<Annotation> Annotations { get; set; }
    }
}
