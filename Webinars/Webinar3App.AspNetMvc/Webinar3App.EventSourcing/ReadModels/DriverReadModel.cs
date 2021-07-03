using EventFlow.Aggregates;
using EventFlow.ReadStores;
using Webinar3App.EventSourcing.Domain.Driver;
using Webinar3App.EventSourcing.Domain.Events;

namespace Webinar3App.EventSourcing.ReadModels
{
    public class DriverReadModel : IReadModel, 
        IAmReadModelFor<DriverAggregate, DriverId, DriverCreatedEvent>,
        IAmReadModelFor<DriverAggregate, DriverId, DriverRemovedEvent>,
        IAmReadModelFor<DriverAggregate, DriverId, CarSetEvent>
    {
        public string AggregateId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ExperienceYears { get; set; }
        
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public string CarNo { get; set; }

        public bool IsRemoved { get; set; }


        public void Apply(
            IReadModelContext context,
            IDomainEvent<DriverAggregate, DriverId, DriverCreatedEvent> domainEvent)
        {
            AggregateId = domainEvent.AggregateIdentity.Value;

            FirstName = domainEvent.AggregateEvent.FirstName;
            LastName = domainEvent.AggregateEvent.LastName;
            ExperienceYears = domainEvent.AggregateEvent.ExperienceYears;
            IsRemoved = false;
        }

        public void Apply(
            IReadModelContext context,
            IDomainEvent<DriverAggregate, DriverId, DriverRemovedEvent> domainEvent)
        {
            IsRemoved = true; 
        }

        public void Apply(
            IReadModelContext context,
            IDomainEvent<DriverAggregate, DriverId, CarSetEvent> domainEvent)
        {
            CarMake = domainEvent.AggregateEvent.Make;
            CarModel = domainEvent.AggregateEvent.Model;
            CarNo = domainEvent.AggregateEvent.No;
        }
    }
}
