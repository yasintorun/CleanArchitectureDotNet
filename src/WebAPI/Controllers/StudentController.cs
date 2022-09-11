using LMS.Application.Modules.Students.Queries;
using LMS.WebAPI.Requests.Defaults;
using LMS.WebAPI.Requests.Student;
using LMS.WebAPI.Responses.Student;
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
        public async Task<IActionResult> GetStudents([FromQuery]DefaultPaginateRequest paginateRequest)
        {
            //var list = _studentRepository.GetList();
            var students = await Mediator.Send(new GetAllStudentsQuery(paginateRequest.To()));
            
            var response = students.ConvertItems(x => new GetStudentsResponse(x.Id, x.Identity, x.FirstName, x.LastName));
            return Ok(students, "listed");
        }


        [HttpPost("")]
        public async Task<IActionResult> AddStudents(AddStudentRequest student)
        {
            //var addedStudent = _studentRepository.Add(student);
            var addedStudent = await Mediator.Send(student.ToCommand());

            AddStudentResponse response = new (addedStudent.id);
            return Ok(response, "added");
        }
    }
}
