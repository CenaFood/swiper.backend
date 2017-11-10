using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ch.cena.swiper.backend.service.Service;
using ch.cena.swiper.backend.service.DTOs;

namespace ch.cena.swiper.backend.api.Controllers
{
    [Route("[controller]")]
    public class AnnotationsController : Controller
    {
        AnnotationService _service;
        
        public AnnotationsController(AnnotationService annotationService)
        {
            _service = annotationService;
        }

        [HttpPost]
        public IActionResult CreateAnnotation([FromBody] AnnotationDTO annotation)
        {
            if (!ModelState.IsValid) {
                BadRequest(ModelState);
            }

            _service.InsertAnnotation(annotation);

            return Ok(annotation);
        }
    }
}