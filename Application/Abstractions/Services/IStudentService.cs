
using CleanArchitecture.Domain.Models;
using System.Linq.Expressions;

namespace CleanArchitecture.Application.Abstractions.Services
{
    public interface IStudentService : IBaseService
    {
        Task<List<Student>> GetStudentsAsync(Expression<Func<Student, bool>>? predicate);
    }
}
