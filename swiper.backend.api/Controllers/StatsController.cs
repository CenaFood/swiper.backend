using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ch.cena.swiper.backend.service.Contracts.Service;
using ch.cena.swiper.backend.service.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ch.cena.swiper.backend.api.Controllers
{
    [Authorize]
    public class StatsController : Controller
    {
        private readonly IStatisticsService _service;
        private readonly IUserService _userService;


        public StatsController(IStatisticsService statsService, IUserService userService)
        {
            _service = statsService;
            _userService = userService;

        }

        [HttpGet("/[controller]")]
        public IActionResult GetStats()
        {
            var user = _userService.GetUserFromUsername(User.FindFirstValue(JwtRegisteredClaimNames.Sub));
            var result = _service.GetStatisticsForUser(user);

            return Json(result);
        }
    }
}