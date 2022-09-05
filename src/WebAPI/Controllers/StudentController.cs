using LMS.Application.Abstractions.Repositories;
using LMS.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IStudentRepository _studentRepository;

        public StudentController(ILogger<StudentController> logger, IStudentRepository studentRepository)
        {
            _logger = logger;
            _studentRepository = studentRepository;
        }

        [HttpGet("")]
        public IActionResult GetStudents()
        {
            var list = _studentRepository.GetList();
            return Ok(list);
        }


        [HttpPost("")]
        public IActionResult AddStudents(Student student)
        {
            var addedStudent = _studentRepository.Add(student);
            return Ok(addedStudent);
        }
    }
}
