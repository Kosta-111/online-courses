using Core.Models;
using FluentValidation;

namespace Core.Validators;

public class PasswordResetTokenRequestValidator : AbstractValidator<PasswordResetTokenRequest>
{
    public PasswordResetTokenRequestValidator()
    {
        RuleFor(x => x.Email)
          .NotEmpty()
          .EmailAddress();
    }
}
