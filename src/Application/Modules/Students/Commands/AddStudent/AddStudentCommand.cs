using LMS.Application.Abstractions.Repositories;
using LMS.Application.Abstractions.Services;
using LMS.Domain.Models;
using MediatR;

namespace LMS.Application.Modules.Students.Commands
{
    public record AddStudentCommand(string FirstName, string LastName, string Identity) : IRequest<AddStudentCommandResponse>;

    public record AddStudentCommandResponse(int id);

    public record AddStudentCommandHandler : IRequestHandler<AddStudentCommand, AddStudentCommandResponse>
    {
        #region BEFORE THE MANAGER CLASS
        // handler can never call the repository.
        /*
        private readonly IStudentRepository _studentRepository;
        public AddStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        */
        #endregion

        #region AFTER THE MANAGER CLASS
        private readonly IStudentService _studentService;

        public AddStudentCommandHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }
        #endregion

        public async Task<AddStudentCommandResponse> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {

            Student newStudent = new (0, request.Identity, request.FirstName, request.LastName);

            var addedStudent = await _studentService.AddAsync(newStudent);

            // No more direct access to the repository. -> Deprecated -> before the manager class
            //var addedStudent = await _studentRepository.AddAsync(newStudent);

            return new AddStudentCommandResponse(addedStudent.Id);
        }
    }
}
