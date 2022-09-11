
using LMS.Core.Domain.Models;
using LMS.Domain.Models;
using System.Linq.Expressions;

namespace LMS.Application.Abstractions.Services
{
    public interface IStudentService : IBaseService<Student>
    {
        Task<Student> AddAsync(Student student);
        Task<Paginate<Student>> GetListAsync(Expression<Func<Student, bool>>? predicate, PaginateRequest request, Func<Student, object>? orderBy = null);
    }
}
