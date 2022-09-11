using LMS.Application.Abstractions.Repositories;
using LMS.Application.Abstractions.Services;
using LMS.Core.Domain.Models;
using LMS.Core.Exceptions;
using LMS.Domain.Models;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using System.Linq;

namespace LMS.Application.Managers
{
    public class StudentManager : BaseManager<Student>, IStudentService
    {
        private readonly ILogger _logger;
        private readonly IStudentRepository _studentRepository;

        public StudentManager(ILogger<StudentManager> logger, IStudentRepository studentRepository)
        {
            _logger = logger;
            _studentRepository = studentRepository;
        }

        public async Task<Student> AddAsync(Student student)
        {
            _logger.LogInformation($"AddStudentAsync method started with @student={student}");
            
            // Example business logic
            var isExistsIdentity = await _studentRepository.GetAsync(x => x.Identity == student.Identity);
            if(isExistsIdentity != null)
            {
                throw new InternalException("dublicatedIdentity");
            }

            var addedStudent = await _studentRepository.AddAsync(student);

            _logger.LogInformation($"AddStudentAsync method finished with @addedStudent={addedStudent}");
            return addedStudent;
        }

        public async Task<Paginate<Student>> GetListAsync(Expression<Func<Student, bool>>? predicate, PaginateRequest request, Func<Student, object>? orderBy = null)
        {
            _logger.LogInformation($"GetStudentListAsync method started with @predicate={predicate}, @paginateRequest={request}");

            return await _studentRepository.GetListWithPaginateAsync(predicate, request, orderBy);
        }
    }
}
