using AutoMapper;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Webinar1App.Entities;
using Webinar3App.AspNetMvc.Application.Events;
using Webinar3App.AspNetMvc.Data;

namespace Webinar3App.AspNetMvc.Application.Commands
{
    public class AddDriverCommand
    {
        public class Command : IRequest
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int ExperienceYears { get; set; }
            public string CarMake { get; set; }
            public string CarModel { get; set; }
            public string CarNo { get; set; }
        }

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
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

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _db;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;

            public Handler(DataContext db, IMediator mediator, IMapper mapper)
            {
                _db = db;
                _mediator = mediator;
                _mapper = mapper;
            }

            public Task<Unit> Handle(Command command, CancellationToken cancellationToken)
            {
                var driver = _mapper.Map<Driver>(command);

                _db.CreateDriver(driver);
                _db.SaveChanges();

                var @event = _mapper.Map<Driver, DriverCreatedEvent>(driver);
                
                _mediator.Publish(@event);

                return Task.FromResult(Unit.Value);
            }
        }
     }
}
