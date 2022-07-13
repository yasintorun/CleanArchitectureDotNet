using CleanArchitecture.Domain.Models;
using CleanArchitecture.Api.Response;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;

        public StudentController(ILogger<StudentController> logger)
        {
            _logger = logger;
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public IActionResult GetResellerInstitutionsByResellerId(Student student)
        {
            return Ok("Başarılı");
        }

    }
}
