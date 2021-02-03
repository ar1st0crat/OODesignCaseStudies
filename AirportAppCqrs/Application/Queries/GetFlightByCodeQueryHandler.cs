using AirportAppCqrs.Data;
using AirportAppCqrs.ViewModel;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AirportAppCqrs.Application.Queries
{
    public class GetFlightByCodeQueryHandler : IRequestHandler<GetFlightByCodeQuery, FlightViewModel>
    {
        public Task<FlightViewModel> Handle(GetFlightByCodeQuery query, CancellationToken cancellationToken)
        {
            var flight = MockRepository.Flights.Where(f => f.Code == query.Code).FirstOrDefault();

            FlightViewModel flightModel = null;

            if (flight != null)
            {
                flightModel = new FlightViewModel      // or use AutoMapper
                {
                    Code = flight.Code,
                    DepartureTime = flight.DepartureTime,
                    DepartureCity = flight.DepartureCity,
                    ArrivalTime = flight.ArrivalTime,
                    ArrivalCity = flight.ArrivalCity,
                    SeatCount = flight.SeatCount
                };
            }

            return Task.FromResult(flightModel);
        }
    }
}
