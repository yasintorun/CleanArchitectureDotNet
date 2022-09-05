using LMS.Application.Abstractions.Repositories;
using LMS.Core.Infrastructure.Database.EntityFramework;
using LMS.Domain.Models;
using LMS.Infrastructure.Database.EntityFramework.Contexts;

namespace LMS.Infrastructure.Database.EntityFramework.Repositories
{
    public class StudentRepository : EfRepository<Student, LMSContext>, IStudentRepository
    {
        public StudentRepository(LMSContext context) : base(context)
        {
        }
    }
}
