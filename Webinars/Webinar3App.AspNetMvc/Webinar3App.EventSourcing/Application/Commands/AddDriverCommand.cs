using EventFlow.Commands;
using System.Threading;
using System.Threading.Tasks;
using Webinar3App.EventSourcing.Domain.Driver;

namespace Webinar3App.EventSourcing.Application.Commands
{
    public class AddDriverCommand : Command<DriverAggregate, DriverId>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ExperienceYears { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public string CarNo { get; set; }

        public AddDriverCommand() : base(DriverId.New)
        {
        }
    }

    internal class AddDriverCommandHandler : CommandHandler<DriverAggregate, DriverId, AddDriverCommand>
    {
        public override Task ExecuteAsync(DriverAggregate aggregate,
            AddDriverCommand command,
            CancellationToken cancellationToken)
        {
            aggregate.CreateDriver(
                command.FirstName,
                command.LastName,
                command.ExperienceYears,
                command.CarMake,
                command.CarModel,
                command.CarNo);

            return Task.CompletedTask;
        }
    }
}
