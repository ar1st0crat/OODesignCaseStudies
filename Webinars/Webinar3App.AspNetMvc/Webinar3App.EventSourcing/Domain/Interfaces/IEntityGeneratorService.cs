using Webinar3App.EventSourcing.Domain.Car;
using Webinar3App.EventSourcing.Domain.Driver;

namespace Webinar3App.EventSourcing.Domain.Interfaces
{
    public interface IEntityGeneratorService
    {
        CarEntity GenerateCar();
        DriverEntity GenerateDriver();
    }
}
