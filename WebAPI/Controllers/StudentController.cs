using CleanArchitecture.Domain.Models;
using CleanArchitecture.Api.Response;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Application.Abstractions.Services;
using MediatR;
using CleanArchitecture.Application.Queries;
using CleanArchitecture.Api.Responses;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IStudentService _studentService;
        private readonly IMediator _mediator;

        public StudentController(ILogger<StudentController> logger, IStudentService studentService, IMediator mediator)
        {
            _logger = logger;
            _studentService = studentService;
            _mediator = mediator;
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetStudentsResponse))]
        public async Task<IActionResult> GetStudents()
        {
            _logger.LogInformation($"GetStudents controller process started");

            var result = await _mediator.Send(new GetStudentsQuery());

            var response = result.ConvertAll(x => GetStudentsResponse.From(x));

            _logger.LogInformation($"GetStudents controller process finished response: {response}");
            return Ok(response);
        }

    }
}
