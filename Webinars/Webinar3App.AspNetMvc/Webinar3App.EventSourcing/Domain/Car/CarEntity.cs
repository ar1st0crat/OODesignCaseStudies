using EventFlow.Entities;

namespace Webinar3App.EventSourcing.Domain.Car
{
    public class CarEntity : Entity<CarId>
    {
        public string Make { get; private set; }
        public string Model { get; private set; }
        public string No { get; private set; }
        public CarColor Color { get; private set; }

        public CarEntity(CarId id, string make, string model, string no, CarColor color = CarColor.White) : base(id)
        {
            Make = make;
            Model = model;
            No = no;
            Color = color;
        }

        public CarEntity() : base(CarId.New)
        {
        }
    }
}
