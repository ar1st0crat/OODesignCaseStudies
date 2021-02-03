using AirportAppCqrs.Data;
using AirportAppCqrs.ViewModel;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AirportAppCqrs.Application.Queries
{
    public class GetFlightsQueryHandler : IRequestHandler<GetFlightsQuery, List<FlightViewModel>>
    {
        public Task<List<FlightViewModel>> Handle(GetFlightsQuery query, CancellationToken cancellationToken)
        {
            return Task.FromResult(
                MockRepository.Flights.Select(f => new FlightViewModel
                {
                    Code = f.Code,
                    ArrivalCity = f.ArrivalCity,
                    DepartureCity = f.DepartureCity
                })
                .ToList());
        }
    }
}
