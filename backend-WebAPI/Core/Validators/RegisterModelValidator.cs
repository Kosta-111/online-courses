using Core.Models;
using FluentValidation;

namespace Core.Validators;

public class RegisterModelValidator : AbstractValidator<RegisterModel>
{
    public RegisterModelValidator()
    {
        RuleFor(x => x.Email)
           .NotEmpty()
           .EmailAddress();

        RuleFor(x => x.BirthDate)
           .LessThanOrEqualTo(DateTime.Now);
    }
}
