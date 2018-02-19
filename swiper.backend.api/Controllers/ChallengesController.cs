using ch.cena.swiper.backend.service.Contracts.Service;
using ch.cena.swiper.backend.service.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace ch.cena.swiper.backend.api.Controllers
{
    [Authorize]    public  class ChallengesController : Controller
    {
        private readonly IChallengeService _service;
        private readonly IUserService _userService;

        public ChallengesController(IChallengeService challengeService, IUserService userService)
        {
            _service = challengeService;
            _userService = userService;
        }

        [HttpGet("challenges")]
        public IActionResult GetChallenges()
        {
            var user = _userService.GetUserFromUsername(User.FindFirstValue(JwtRegisteredClaimNames.Sub));
            var result = _service.GetChallenges(user);

            if (result == null || result.Count() < 1) return NotFound("No more challanges for you");
            return Json(result);
        }

        [HttpGet("projects/{projectID:Guid}/[controller]")]
        public IActionResult GetChallengesByProject(Guid projectID)
        {
            var user = _userService.GetUserFromUsername(User.FindFirstValue(JwtRegisteredClaimNames.Sub));
            var result = _service.GetChallengesFor(user, projectID);

            if (result == null || result.Count() < 1) return NotFound("No more challenges for specified project");
            return Json(result);
        }

        [HttpGet("[controller]/{type}")]
        public IActionResult GetChallengesByType(string type)
        {
            var result = _service.GetChallengesOf(UserDTO.GetDummy(), type);

            if (result == null || result.Count() < 1) return NotFound("No more challenges of specified type");
            return Json(result);
        }

    }
}