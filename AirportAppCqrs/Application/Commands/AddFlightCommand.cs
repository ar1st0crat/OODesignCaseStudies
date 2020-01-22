using MediatR;
using System;

namespace AirportAppCqrs.Application.Commands
{
    public class AddFlightCommand : IRequest
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public string Code { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int? SeatCount { get; set; }
    }
}
