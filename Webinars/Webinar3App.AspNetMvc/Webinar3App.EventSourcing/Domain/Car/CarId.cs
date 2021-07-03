using EventFlow.Core;

namespace Webinar3App.EventSourcing.Domain.Car
{
    public class CarId : Identity<CarId>
    {
        public CarId(string value) : base(value) { }
    }
}
