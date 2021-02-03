using AirportAppCqrs.Application.Notifications;
using AirportAppCqrs.Data;
using AirportAppCqrs.Domain;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AirportAppCqrs.Application.Commands
{
    public class AddFlightCommandHandler : AsyncRequestHandler<AddFlightCommand>
    {
        private readonly IMediator _mediator;

        public AddFlightCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected override Task Handle(AddFlightCommand command, CancellationToken cancellationToken)
        {
            var flight = new Flight
            {
                Id = MockRepository.Flights.Max(f => f.Id) + 1,
                Company = MockRepository.Companies.FirstOrDefault(c => c.Id == command.CompanyId),
                Code = command.Code,
                DepartureCity = command.DepartureCity,
                DepartureTime = command.DepartureTime,
                ArrivalCity = command.ArrivalCity,
                ArrivalTime = command.ArrivalTime,
                SeatCount = command.SeatCount
            };

            MockRepository.Flights.Add(flight);

            _mediator.Publish(new FlightAddedNotification(flight));

            return Task.CompletedTask;
        }
    }
}
