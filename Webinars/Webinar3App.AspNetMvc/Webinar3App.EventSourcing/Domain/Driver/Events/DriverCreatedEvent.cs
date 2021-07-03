using EventFlow.Aggregates;
using EventFlow.EventStores;
using Webinar3App.EventSourcing.Domain.Driver;

namespace Webinar3App.EventSourcing.Domain.Events
{
    [EventVersion("create driver", 1)]
    public class DriverCreatedEvent : AggregateEvent<DriverAggregate, DriverId>
    {
        public string FirstName { get; }
        public string LastName { get; }
        public int ExperienceYears { get; }

        public DriverCreatedEvent(string firstname, string lastname, int experienceYears)
        {
            FirstName = firstname;
            LastName = lastname;
            ExperienceYears = experienceYears;
        }
    }
}
