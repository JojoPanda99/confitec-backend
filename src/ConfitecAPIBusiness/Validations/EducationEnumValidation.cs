using ConfitecAPIBusiness.Models;
using FluentValidation;

namespace ConfitecAPIBusiness.Validations;

public class EducationEnumValidation : AbstractValidator<EducationEnum>
{
    public EducationEnumValidation()
    {
        RuleFor(x => x)
            .NotEmpty()
            .WithMessage("Education is required")
            .IsInEnum()
            .WithMessage("Education is invalid");
    }
}