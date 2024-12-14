using Core.Models;
using FluentValidation;

namespace Core.Validators;

public class CourseEditValidator : AbstractValidator<CourseModelEdit>
{
    public CourseEditValidator()
    {
        Include(new CourseCreateValidator());

        RuleFor(x => x.Id).GreaterThan(0);
    }
}
