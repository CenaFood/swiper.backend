﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ch.cena.swiper.backend.data.Models
{
    public class Answer : BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public string Text { get; set; }

        [Required]
        public Guid ChallengeTypeID { get; set; }

        public ChallengeType ChallengeTypes;
    }
}
