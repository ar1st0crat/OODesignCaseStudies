using EventFlow.Aggregates.ExecutionResults;
using EventFlow.Snapshots;
using EventFlow.Snapshots.Strategies;
using System.Threading;
using System.Threading.Tasks;
using Webinar3App.EventSourcing.Domain.Car;
using Webinar3App.EventSourcing.Domain.Events;
using Webinar3App.EventSourcing.Domain.Interfaces;

namespace Webinar3App.EventSourcing.Domain.Driver
{
    public class DriverAggregate : SnapshotAggregateRoot<DriverAggregate, DriverId, DriverSnapshot>
    {
        private readonly DriverAggregateState _driverAggregateState = new DriverAggregateState();
        private readonly IEntityGeneratorService _generator;

        public DriverAggregate(DriverId id, IEntityGeneratorService generator) : base(id, SnapshotEveryFewVersionsStrategy.With(10))
        {
            Register(_driverAggregateState);

            _generator = generator;
        }

        public IExecutionResult CreateDriver(string firstname, string lastname, int experienceYears, string carMake, string carModel, string carNo)
        {
            // ==== emit 2 events (or use Saga here):

            Emit(new DriverCreatedEvent(firstname, lastname, experienceYears));
            
            Emit(new CarSetEvent(CarId.New, carMake, carModel, carNo));

            // ======================================

            return ExecutionResult.Success();
        }

        public IExecutionResult GenerateDriver()
        {
            var car = _generator.GenerateCar();
            var driver = _generator.GenerateDriver();

            return CreateDriver(driver.FirstName, driver.LastName, driver.ExperienceYears, car.Make, car.Model, car.No);
        }

        public IExecutionResult RemoveDriver()
        {
            Emit(new DriverRemovedEvent(Id.Value));

            return ExecutionResult.Success();
        }


        protected override Task<DriverSnapshot> CreateSnapshotAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(new DriverSnapshot(_driverAggregateState));
        }

        protected override Task LoadSnapshotAsync(DriverSnapshot snapshot, ISnapshotMetadata metadata, CancellationToken cancellationToken)
        {
            _driverAggregateState.LoadSnapshot(snapshot);
            return Task.CompletedTask;
        }
    }
}
