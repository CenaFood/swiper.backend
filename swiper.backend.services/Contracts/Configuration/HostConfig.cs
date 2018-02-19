using System;
using System.Collections.Generic;
using System.Text;

namespace ch.cena.swiper.backend.service.Contracts.Configuration
{
    public class HostConfig
    {
        public string HostingUri { get; set; }
        public string ImageHostFolder { get; set; }
        public string JwtKey { get; set; }
        public string JwtIssuer { get; set; }
        public double JwtExpireDays { get; set; }
    }
}
