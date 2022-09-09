﻿using LMS.Application.Abstractions.Repositories;
using LMS.Domain.Models;
using MediatR;

namespace LMS.Application.Modules.Students.Commands
{
    public record AddStudentCommand(string FirstName, string LastName, string Identity) : IRequest<AddStudentCommandResponse>;
    //public class AddStudentCommand : IRequest<AddStudentCommandResponse>
    //{
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public string Identity { get; set; }

    //    public AddStudentCommand(string firstName, string lastName, string ıdentity)
    //    {
    //        FirstName = firstName;
    //        LastName = lastName;
    //        Identity = ıdentity;
    //    }
    //}

    public record AddStudentCommandResponse();

    public record AddStudentCommandHandler : IRequestHandler<AddStudentCommand, AddStudentCommandResponse>
    {
        private readonly IStudentRepository _studentRepository;

        public AddStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<AddStudentCommandResponse> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var newStudent = new Student
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Identity = request.Identity,
            };
            var addedStudent = await _studentRepository.AddAsync(newStudent);

            return new AddStudentCommandResponse();
        }
    }
}