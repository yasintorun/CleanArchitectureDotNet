
using LMS.Domain.Models;

namespace LMS.Application.Abstractions.Services
{
    public interface IStudentService : IBaseService<Student>
    {
        Task<Student> AddAsync(Student student);
    }
}
