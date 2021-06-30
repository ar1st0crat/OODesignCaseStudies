using AutoMapper;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Webinar3App.AspNetMvc.Data;
using Webinar3App.AspNetMvc.Domain.Aggregates;
using Webinar3App.AspNetMvc.Domain.Events;

namespace Webinar3App.AspNetMvc.Application.Commands
{
    public class GenerateDriverCommand
    {
        public class Command : IRequest
        {
        }

        public class Validator : AbstractValidator<Command>
        {
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
                var driver = _db.Generate();

                _db.CreateDriver(driver);
                _db.SaveChanges();

                var @event = _mapper.Map<Driver, DriverCreatedEvent>(driver);

                //await _mediator.Publish(@event);
                _mediator.Publish(@event);

                //return Unit.Value;
                return Task.FromResult(Unit.Value);
            }
        }
    }
}
