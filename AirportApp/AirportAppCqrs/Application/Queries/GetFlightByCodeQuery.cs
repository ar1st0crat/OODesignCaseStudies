using AirportAppCqrs.ViewModel;
using MediatR;

namespace AirportAppCqrs.Application.Queries
{
    public class GetFlightByCodeQuery : IRequest<FlightViewModel>
    {
        public string Code { get; set; }
    }
}
