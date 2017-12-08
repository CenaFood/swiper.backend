using ch.cena.swiper.backend.service.DTOs;
using ch.cena.swiper.backend.services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ch.cena.swiper.backend.api.Controllers
{
    public  class ChallengesController : Controller
    {
        private readonly IChallengeService _service;

        public ChallengesController(IChallengeService challengeService)
        {
            _service = challengeService;
        }

        [HttpGet("challenges")]
        public IActionResult GetChallenges()
        {
            var result = _service.GetChallenges(UserDTO.GetDummy());

            if (result == null || result.Count() < 1) return NotFound("No more challanges for you");
            return Json(result);
        }

        [HttpGet("projects/{projectID:Guid}/[controller]")]
        public IActionResult GetChallengesByProject(Guid projectID)
        {
            var result = _service.GetChallengesFor(UserDTO.GetDummy(), projectID);

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