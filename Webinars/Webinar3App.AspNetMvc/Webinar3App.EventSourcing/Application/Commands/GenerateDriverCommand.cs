using EventFlow.Commands;
using System.Threading;
using System.Threading.Tasks;
using Webinar3App.EventSourcing.Domain.Driver;

namespace Webinar3App.EventSourcing.Application.Commands
{
    public class GenerateDriverCommand : Command<DriverAggregate, DriverId>
    {
        public GenerateDriverCommand() : base(DriverId.New)
        {
        }
    }

    internal class GenerateDriverCommandHandler : CommandHandler<DriverAggregate, DriverId, GenerateDriverCommand>
    {
        public override Task ExecuteAsync(DriverAggregate aggregate,
            GenerateDriverCommand command,
            CancellationToken cancellationToken)
        {
            aggregate.GenerateDriver();

            return Task.CompletedTask;
        }
    }
}
