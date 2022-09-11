using LMS.Application.Abstractions.Repositories;
using LMS.Application.Abstractions.Services;
using LMS.Core.Exceptions;
using LMS.Domain.Models;
using Microsoft.Extensions.Logging;

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
            _logger.LogInformation($"AddStudentAsync method started with student=@{student}");
            
            // Example business logic
            var isExistsIdentity = await _studentRepository.GetAsync(x => x.Identity == student.Identity);
            if(isExistsIdentity != null)
            {
                throw new Exception("dublicatedIdentity");
            }

            var addedStudent = await _studentRepository.AddAsync(student);

            _logger.LogInformation($"AddStudentAsync method finished with addedStudent=@{addedStudent}");
            return addedStudent;
        }
    }
}
