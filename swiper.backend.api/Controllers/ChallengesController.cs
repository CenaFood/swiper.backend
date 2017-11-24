using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ch.cena.swiper.backend.service.Service;
using ch.cena.swiper.backend.service.Contracts.Entities;
using ch.cena.swiper.backend.service.DTOs;

namespace ch.cena.swiper.backend.api.Controllers
{
    public class ChallengesController : Controller
    {
        ChallengeService _service;


        public ChallengesController(ChallengeService challengeService)
        {
            _service = challengeService;
        }

        [HttpGet("[controller]")]
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