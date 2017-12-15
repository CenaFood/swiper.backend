using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ch.cena.swiper.backend.data.Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required]
        [MaxLength(62)]
        public string MailAddress { get; set; }

        public ICollection<Annotation> Annotations { get; set; }
    }
}
