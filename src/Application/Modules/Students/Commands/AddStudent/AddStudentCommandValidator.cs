
using FluentValidation;
using LMS.Application.Constants.Messages;
using LMS.Application.Modules.Students.Commands;

namespace LMS.Application.Modules.Students.Validators
{
    public class AddStudentCommandValidator : AbstractValidator<AddStudentCommand>
    {
        public AddStudentCommandValidator()
        {
            RuleFor(s => s.Identity).NotEmpty().WithMessage(Messages.NotEmpty);
            RuleFor(s => s.Identity).NotNull().WithMessage(Messages.NotNull);
            RuleFor(s => s.Identity).Length(11, 11).WithMessage(Messages.IdentityLengthMust11);
            RuleFor(s => s.Identity).Length(11, 11).WithMessage(Messages.IdentityLengthMust11);

            RuleFor(s => s.FirstName).NotEmpty().WithMessage(Messages.NotEmpty);
            RuleFor(s => s.FirstName).NotNull().WithMessage(Messages.NotNull);
            RuleFor(s => s.FirstName).Length(3, 30).WithMessage(Messages.LastnameLengthMustBetween3And30);

            RuleFor(s => s.LastName).NotEmpty().WithMessage(Messages.NotEmpty);
            RuleFor(s => s.LastName).NotNull().WithMessage(Messages.NotNull);
            RuleFor(s => s.LastName).Length(3, 30).WithMessage(Messages.LastnameLengthMustBetween3And30);
        }
    }
}
