using FluentValidation;
using Webinar3App.EventSourcing.Application.Commands;

namespace Webinar3App.EventSourcing.Application.Validators
{
    public class AddDriverCommandValidator : AbstractValidator<AddDriverCommand>
    {
        public AddDriverCommandValidator()
        {
            RuleFor(cmd => cmd.FirstName).NotEmpty();
            RuleFor(cmd => cmd.LastName).NotEmpty();
            RuleFor(cmd => cmd.ExperienceYears).GreaterThan(0);
            RuleFor(cmd => cmd.CarMake).NotEmpty();
            RuleFor(cmd => cmd.CarModel).NotEmpty();
            RuleFor(cmd => cmd.CarNo).NotEmpty()
                .Matches(@"^[a-zA-Z]\d{3}[a-zA-Z]{2}$")
                .WithMessage("Examples: A123BC, X705QA, etc.");
        }
    }
}
