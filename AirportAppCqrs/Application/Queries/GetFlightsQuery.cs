using AirportAppCqrs.ViewModel;
using MediatR;
using System.Collections.Generic;

namespace AirportAppCqrs.Application.Queries
{
    public class GetFlightsQuery : IRequest<List<FlightViewModel>>
    {
    }
}