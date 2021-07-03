using Bogus;
using Webinar3App.EventSourcing.Domain.Car;
using Webinar3App.EventSourcing.Domain.Driver;
using Webinar3App.EventSourcing.Domain.Interfaces;

namespace Webinar3App.EventSourcing.Infrastructure
{
    public class EntityGeneratorService : IEntityGeneratorService
    {
        private readonly Faker<DriverEntity> _driversFaker;
        private readonly Faker<CarEntity> _carsFaker;

        public EntityGeneratorService()
        {
            var gender = Bogus.DataSets.Name.Gender.Male;

            _driversFaker = new Faker<DriverEntity>()
                .RuleFor(u => u.FirstName, f => f.Name.FirstName(gender))
                .RuleFor(u => u.LastName, f => f.Name.LastName(gender))
                .RuleFor(u => u.ExperienceYears, f => f.Random.Int(1, 10));

            _carsFaker = new Faker<CarEntity>()
                .RuleFor(u => u.Make, f => f.Vehicle.Manufacturer())
                .RuleFor(u => u.Model, f => f.Vehicle.Model())
                .RuleFor(u => u.No, f => f.Random.Replace("?###??"))
                .RuleFor(u => u.Color, f => f.Random.Enum<CarColor>());
        }

        public CarEntity GenerateCar()
        {
            return _carsFaker.Generate();
        }

        public DriverEntity GenerateDriver()
        {
            return _driversFaker.Generate();
        }
    }
}
