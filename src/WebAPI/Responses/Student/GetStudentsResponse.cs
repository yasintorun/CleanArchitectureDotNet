using LMS.Application.Modules.Students.Commands;

namespace LMS.WebAPI.Responses.Student
{
    public record GetStudentsResponse (int id, string identity, string firstname, string lastname)
    {
        
    }
}
