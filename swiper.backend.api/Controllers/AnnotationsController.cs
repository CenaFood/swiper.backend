using Microsoft.AspNetCore.Mvc;
using ch.cena.swiper.backend.service.DTOs;
using ch.cena.swiper.backend.service.Contracts.Service;
using ch.cena.swiper.backend.service.Contracts.Entities;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace ch.cena.swiper.backend.api.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class AnnotationsController : Controller
    {
        IAnnotationService _annotationService;
        IUserService _userService;
        

        public AnnotationsController(IAnnotationService annotationService, IUserService userService)
        {
            _annotationService = annotationService;
            _userService = userService;
        }

        [HttpPost]
        public IActionResult CreateAnnotation([FromBody] AnnotationDTO annotation)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            var userId = _userService.GetUserFromEmail(User.FindFirstValue(JwtRegisteredClaimNames.Sub)).ID;

            annotation.UserID = userId;
            _annotationService.InsertAnnotation(annotation);

            return Created("controller", annotation);
        }

        //[HttpPost]
        //public IActionResult CreateAnnotation([FromBody] IEnumerable<IAnnotation> annotations)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        BadRequest(ModelState);
        //    }

        //    foreach(var annotation in annotations)
        //        _annotationervice.InsertAnnotation(annotation);

        //    return Ok();
        //}
    }
}