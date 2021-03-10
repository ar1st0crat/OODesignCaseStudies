using Bogus;
using System.Collections.Generic;
using System.Linq;
using Webinar1App.Entities;

namespace Webinar1App.Data
{
    /// <summary>
    /// Это заглушечный репозиторий, работающий с набором фейковых данных
    /// </summary>
    class MockRepository : IRepository
    {
        private readonly List<Driver> _drivers;
        private readonly Faker<Driver> _driversFaker;

        public MockRepository()
        {
            var fakeCars = new Faker<Car>("ru")
                .RuleFor(u => u.Id, f => f.UniqueIndex / 2 + 1)
                .RuleFor(u => u.Make, f => f.Vehicle.Manufacturer())
                .RuleFor(u => u.Model, f => f.Vehicle.Model())
                .RuleFor(u => u.No, f => f.Random.Replace("?###??"))
                .RuleFor(u => u.Color, f => f.Random.Enum<CarColor>());

            var gender = Bogus.DataSets.Name.Gender.Male;

            _driversFaker = new Faker<Driver>("ru")
                .RuleFor(u => u.Id, f => f.UniqueIndex / 2 + 1)
                .RuleFor(u => u.FirstName, f => f.Name.FirstName(gender))
                .RuleFor(u => u.LastName, f => f.Name.LastName(gender))
                .RuleFor(u => u.ExperienceYears, f => f.Random.Int(1, 10))
                .RuleFor(u => u.Car, f => fakeCars.Generate());

            _drivers = _driversFaker.Generate(10);
        }

        public IEnumerable<Driver> GetDrivers()
        {
            return _drivers;
        }

        public void AddDriver(Driver driver)
        {
            if (driver == null)
            {
                driver = _driversFaker.Generate();
            }

            driver.Id = _drivers.Max(d => d.Id) + 1;
            driver.Car.Id = _drivers.Max(d => d.Car.Id) + 1;

            _drivers.Add(driver);
        }

        public void RemoveDriver(int id)
        {
            var driver = _drivers.FirstOrDefault(d => d.Id == id);

            if (driver != null)
            {
                _drivers.Remove(driver);
            }
        }
    }
}
