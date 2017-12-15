using Microsoft.AspNetCore.Mvc;
using ch.cena.swiper.backend.service.DTOs;
using ch.cena.swiper.backend.services.Contracts;
using ch.cena.swiper.backend.service.Contracts.Entities;
using System.Collections.Generic;

namespace ch.cena.swiper.backend.api.Controllers
{
    [Route("[controller]")]
    public class AnnotationsController : Controller
    {
        IAnnotationService _service;
        
        public AnnotationsController(IAnnotationService annotationService)
        {
            _service = annotationService;
        }

        [HttpPost]
        public IActionResult CreateAnnotation([FromBody] IAnnotation annotation)
        {
            if (!ModelState.IsValid) {
                BadRequest(ModelState);
            }

            _service.InsertAnnotation(annotation);

            return Ok();
        }

        //[HttpPost]
        //public IActionResult CreateAnnotation([FromBody] IEnumerable<IAnnotation> annotations)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        BadRequest(ModelState);
        //    }

        //    foreach(var annotation in annotations)
        //        _service.InsertAnnotation(annotation);

        //    return Ok();
        //}
    }
}