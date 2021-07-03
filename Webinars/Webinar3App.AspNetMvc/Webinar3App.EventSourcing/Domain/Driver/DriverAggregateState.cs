using EventFlow.Aggregates;
using System;
using Webinar3App.EventSourcing.Domain.Events;

namespace Webinar3App.EventSourcing.Domain.Driver
{
    [Serializable]
    public class DriverAggregateState : AggregateState<DriverAggregate, DriverId, DriverAggregateState>,
                                        IApply<DriverCreatedEvent>,
                                        IApply<DriverRemovedEvent>
    {
        public DriverEntity Driver { get; set; }

        public void Apply(DriverCreatedEvent aggregateRegisteredEvent)
        {
            Driver = new DriverEntity(
                DriverId.New,
                aggregateRegisteredEvent.FirstName,
                aggregateRegisteredEvent.LastName,
                aggregateRegisteredEvent.ExperienceYears);
        }

        public void Apply(DriverRemovedEvent aggregateRegisteredEvent)
        {
            Driver.MarkAsRemoved();
        }

        public void Apply(CarSetEvent aggregateRegisteredEvent)
        {
            Driver.SetCarWithId(aggregateRegisteredEvent.CarId);
        }

        public void LoadSnapshot(DriverSnapshot snapshot)
        {
            Driver = snapshot.DriverState.Driver;
        }
    }
}
