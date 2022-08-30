using CleanArchitecture.Domain.Models;
using FluentValidation;

namespace CleanArchitecture.Domain.Validations
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(p => p.Name)
                .NotNull().WithMessage("Öğrenci adı zorunlu")
                .NotEmpty().WithMessage("Öğrenci adı boş olamaz")
                .MinimumLength(3).WithMessage("Öğrenci adı en az 3 harf olmalıdır")
                .MaximumLength(30).WithMessage("Öğrenci adı en fazla 30 harf olabilir");

            RuleFor(p => p.StudentNumber)
                .NotNull().WithMessage("Öğrenci numarası zorunlu")
                .NotEmpty().WithMessage("Öğrenci numarası boş olamaz")
                .Length(8).WithMessage("Öğrenci numarası 8 haneli olmalı");
        }
    }
}
