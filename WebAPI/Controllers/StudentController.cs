using CleanArchitecture.Domain.Models;
using CleanArchitecture.Api.Response;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Application.Abstractions.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IStudentService _studentService;

        public StudentController(ILogger<StudentController> logger, IStudentService studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public IActionResult AddStudent(Student student)
        {
            return Ok("Başarılı");
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _studentService.GetStudentsAsync(null);
            return Ok(students);
        }

    }
}
