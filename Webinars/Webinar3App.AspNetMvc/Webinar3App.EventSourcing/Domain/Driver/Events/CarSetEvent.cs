using EventFlow.Aggregates;
using EventFlow.EventStores;
using Webinar3App.EventSourcing.Domain.Car;
using Webinar3App.EventSourcing.Domain.Driver;

namespace Webinar3App.EventSourcing.Domain.Events
{
    [EventVersion("set car", 1)]
    public class CarSetEvent : AggregateEvent<DriverAggregate, DriverId>
    {
        public CarId CarId { get; set; }
        public string Make { get; }
        public string Model { get; }
        public string No { get; }
        public CarColor Color { get; }

        public CarSetEvent(CarId carId, string make, string model, string no, CarColor color = CarColor.White)
        {
            CarId = carId;
            Make = make;
            Model = model;
            No = no;
            Color = color;
        }
    }
}
