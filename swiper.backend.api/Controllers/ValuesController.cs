﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ch.cena.swiper.backend.service.DTOs;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace ch.cena.swiper.backend.api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        [Authorize]
        public IEnumerable<string> Get()
        {
            var email = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            return new string[] { "value1", "value2", email };
        }

        // GET api/values/5
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var resutl = new ImageDTO();
            resutl.Height = 400;
            resutl.Width = 400;
            resutl.FileName = "23825329_702402206622090_500261469762355200_n.jpg";
            resutl.Url = "https://scontent-amt2-1.cdninstagram.com/t51.2885-15/e35/23825329_702402206622090_500261469762355200_n.jpg";
            return Json(resutl);
        }

        // POST api/values
        [Authorize]
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
