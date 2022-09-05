using LMS.Application.Abstractions.Repositories;
using LMS.Application.Modules.Students.Queries;
using LMS.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.WebAPI.Controllers
{
    public class StudentController : ApiControllerBase
    {
        private readonly ILogger _logger;
        private readonly IStudentRepository _studentRepository;

        public StudentController(ILogger<StudentController> logger, IStudentRepository studentRepository)
        {
            _logger = logger;
            _studentRepository = studentRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetStudents()
        {
            //var list = _studentRepository.GetList();
            var students = await Mediator.Send(new GetAllStudentsQuery());
            return Ok(students);
        }


        [HttpPost("")]
        public IActionResult AddStudents(Student student)
        {
            var addedStudent = _studentRepository.Add(student);
            return Ok(addedStudent);
        }
    }
}
