using AirportAppCqrs.Domain;
using MediatR;

namespace AirportAppCqrs.Application.Notifications
{
    public class FlightAddedNotification : INotification
    {
        public FlightAddedNotification(Flight flight)
        {
            Flight = flight;
        }

        public Flight Flight { get; private set; }
    }
}
