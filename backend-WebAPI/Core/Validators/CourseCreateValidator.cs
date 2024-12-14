using Core.Models;
using FluentValidation;

namespace Core.Validators;

public class CourseCreateValidator : AbstractValidator<CourseModelCreate>
{
    public CourseCreateValidator()
    {
        RuleFor(x => x.Name)
           .NotEmpty()
           .MinimumLength(2)
           .MaximumLength(50)
           .Matches("[A-Z].*").WithMessage("{PropertyName} must starts with uppercase letter!");

        RuleFor(x => x.Language)
           .NotEmpty()
           .MinimumLength(2)
           .MaximumLength(50);

        RuleFor(x => x.Discount).InclusiveBetween(0, 100);

        RuleFor(x => x.Price).GreaterThanOrEqualTo(0);

        RuleFor(x => x.Rating).InclusiveBetween(0, 5);

        RuleFor(x => x.CategoryId)
            .NotNull()
            .NotEmpty()
            .GreaterThan(0);

        RuleFor(x => x.LevelId)
            .NotNull()
            .NotEmpty()
            .GreaterThan(0);

        RuleFor(x => x.Description).MaximumLength(2000);

        RuleFor(x => x.IsCertificate).NotNull();
    }
}
