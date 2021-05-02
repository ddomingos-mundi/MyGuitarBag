using Microsoft.AspNetCore.Mvc;
using MyGuitarBag.Api.Mock;
using MyGuitarBag.Models.Request;
using System;

namespace MyGuitarBag.Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class GuitarsController : ControllerBase
    {
        private readonly IGuitarMockService _service;

        public GuitarsController(IGuitarMockService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Post([FromBody] PostGuitarRequest request)
        {
            var response = _service.Create(request);
            return Created($"/guitars/{response.Id}", response);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(Guid id)
        {
            _service.Delete(id);
            return NoContent();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            var response = _service.Get(id);
            int statusCode = response == null ? 404 : 200;

            return StatusCode(statusCode, response);
        }

        [HttpGet]
        public IActionResult Get([FromQuery] GetGuitarFiltersRequest request)
        {
            return Ok(_service.GetAll(request));
        }
    }
}
