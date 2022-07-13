using CleanArchitecture.Domain.Models;
using CleanArchitecture.Domain.Database.EFCore;
using CleanArchitecture.Infrastructure.Database.EFCore.Contexts;
using Application.Abstractions.Repositories;

namespace CleanArchitecture.Infrastructure.Database.EFCore.Repositories
{
    public class StudentRepository : EFCoreBaseRepository<Student, ProjectContext>, IStudentRepository
    {
    }
}
