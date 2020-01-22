using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace AirportAppCqrs.Application.Notifications
{
    public class FlightAddedNotificationHandler : INotificationHandler<FlightAddedNotification>
    {
        public Task Handle(FlightAddedNotification notification, CancellationToken cancellationToken)
        {
            // here we can update our read model
            // ...
            MessageBox.Show("Read model has been updated!");

            return Task.CompletedTask;
        }
    }
}
