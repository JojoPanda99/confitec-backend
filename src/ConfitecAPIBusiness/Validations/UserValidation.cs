using ConfitecAPIBusiness.Models;
using FluentValidation;

namespace ConfitecAPIBusiness.Validations;

public class UserValidation : AbstractValidator<User>
{
    public UserValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required")
            .MaximumLength(255)
            .WithMessage("Name must be less than 255 characters");

        RuleFor(x => x.Surname)
            .NotEmpty()
            .WithMessage("Surname is required")
            .MaximumLength(255)
            .WithMessage("Surname must be less than 255 characters");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required")
            .EmailAddress()
            .WithMessage("Email is invalid")
            .MaximumLength(255)
            .WithMessage("Email must be less than 255 characters");

        RuleFor(x => x.BirthDate)
            .NotEmpty()
            .WithMessage("BirthDate is required")
            .LessThan(DateTime.Now)
            .WithMessage("BirthDate must be less than today");
        RuleFor(u => u.Education)
            .NotNull()
            .WithMessage("Education is required")
            .IsInEnum()
            .WithMessage("Education is invalid");
    }
}