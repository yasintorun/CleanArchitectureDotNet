using Application.Abstractions.Repositories;
using CleanArchitecture.Application.Abstractions.Services;
using CleanArchitecture.Domain.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly ILogger<StudentService> _logger;
        private readonly IStudentRepository _studentRepository;

        public StudentService(ILogger<StudentService> logger, IStudentRepository studentRepository)
        {
            _logger = logger;
            _studentRepository = studentRepository;
        }

        public async Task<List<Student>> GetStudentsAsync(Expression<Func<Student, bool>>? predicate)
        {
            _logger.LogInformation($"GetStudents process started with predicate: {predicate}");

            var students = await _studentRepository.GetAsync(predicate);

            _logger.LogInformation($"GetStudents process finished with students: {students}");
            
            return students;
        }
    }
}
