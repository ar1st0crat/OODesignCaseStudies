using EventFlow.Aggregates;
using EventFlow.EventStores;
using Webinar3App.EventSourcing.Domain.Driver;

namespace Webinar3App.EventSourcing.Domain.Events
{
    [EventVersion("remove driver", 1)]
    public class DriverRemovedEvent : AggregateEvent<DriverAggregate, DriverId>
    {
        public string DriverId { get; }

        public DriverRemovedEvent(string driverId)
        {
            DriverId = driverId;
        }
    }
}
