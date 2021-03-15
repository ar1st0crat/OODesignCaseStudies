using FluentValidation;

namespace Webinar2App.Caliburn.ViewModels.Validators
{
    class DriverViewModelValidator : AbstractValidator<DriverWindowViewModel>
    {
        public DriverViewModelValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.ExperienceYears).GreaterThan(0);
            RuleFor(x => x.CarMake).NotEmpty();
            RuleFor(x => x.CarModel).NotEmpty();
            RuleFor(x => x.CarNo).NotEmpty()
                                 .Matches(@"^[a-zA-Z]\d{3}[a-zA-Z]{2}$")
                                 .WithMessage("Examples: A123BC, X705QA, etc.");
        }
    }
}
