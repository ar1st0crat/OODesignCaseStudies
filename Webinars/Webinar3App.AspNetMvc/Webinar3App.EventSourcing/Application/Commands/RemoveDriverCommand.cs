using EventFlow.Commands;
using System.Threading;
using System.Threading.Tasks;
using Webinar3App.EventSourcing.Domain.Driver;

namespace Webinar3App.EventSourcing.Application.Commands
{
    public class RemoveDriverCommand : Command<DriverAggregate, DriverId>
    {
        public RemoveDriverCommand(string driverId) : base(DriverId.With(driverId))
        {
        }
    }

    internal class RemoveDriverCommandHandler : CommandHandler<DriverAggregate, DriverId, RemoveDriverCommand>
    {
        public override Task ExecuteAsync(DriverAggregate aggregate,
            RemoveDriverCommand command,
            CancellationToken cancellationToken)
        {
            aggregate.RemoveDriver(); // UnregisterDriver

            return Task.CompletedTask;
        }
    }
}
