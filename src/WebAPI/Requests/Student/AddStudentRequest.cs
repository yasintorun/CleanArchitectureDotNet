using LMS.Application.Modules.Students.Commands;

namespace LMS.WebAPI.Requests.Student
{
    public record AddStudentRequest (string identity, string firstname, string lastname)
    {
        public AddStudentCommand ToCommand()
        {
            return new AddStudentCommand(firstname, lastname, identity);
        }
    }
}
