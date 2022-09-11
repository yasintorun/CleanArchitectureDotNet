using LMS.Application.Modules.Students.Queries;
using LMS.WebAPI.Requests.Student;
using Microsoft.AspNetCore.Mvc;

namespace LMS.WebAPI.Controllers
{
    public class StudentController : ApiControllerBase
    {
        private readonly ILogger _logger;

        public StudentController(ILogger<StudentController> logger)
        {
            _logger = logger;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetStudents()
        {
            //var list = _studentRepository.GetList();
            var students = await Mediator.Send(new GetAllStudentsQuery());
            return Ok(students, "listed");
        }


        [HttpPost("")]
        public async Task<IActionResult> AddStudents(AddStudentRequest student)
        {
            //var addedStudent = _studentRepository.Add(student);
            var addedStudent = await Mediator.Send(student.ToCommand());
            return Ok(addedStudent, "added");
        }
    }
}
