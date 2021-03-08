using Bogus;
using System.Collections.Generic;
using System.Linq;
using Webinar1App.Entities;

namespace Webinar1App.Services
{
    class DriverService : IDriverService
    {
        private readonly DataContext _dataContext = new DataContext();

        public IEnumerable<Driver> GetDrivers()
        {
            return _dataContext.Drivers;
        }

        public void AddDriver(Driver driver)
        {
            if (driver != null)
            {
                // validate ...

                _dataContext.Drivers.Add(driver);
            }
            else
            {
                _dataContext.Drivers.Add(_dataContext.Generate());
            }

            _dataContext.SaveChanges();
        }

        public void RemoveDriver(int id)
        {
            var driver = _dataContext.Drivers.FirstOrDefault(d => d.Id == id);

            if (driver != null)
            {
                _dataContext.Drivers.Remove(driver);
                _dataContext.SaveChanges();
            }
        }
    }

    /// <summary>
    /// Некоторая эмуляция DbContext из ORM
    /// </summary>
    class DataContext
    {
        private readonly Faker<Driver> _driversFaker;

        public List<Driver> Drivers { get; private set; }

        public DataContext()
        {
            var fakeCars = new Faker<Car>("ru")
                .RuleFor(u => u.Id, f => f.UniqueIndex + 1)
                .RuleFor(u => u.Make, f => f.Vehicle.Manufacturer())
                .RuleFor(u => u.Model, f => f.Vehicle.Model())
                .RuleFor(u => u.No, f => f.Random.Replace("?###??"))
                .RuleFor(u => u.Color, f => f.Random.Enum<CarColor>());

            var gender = Bogus.DataSets.Name.Gender.Male;

            _driversFaker = new Faker<Driver>("ru")
                .RuleFor(u => u.Id, f => f.UniqueIndex + 1)
                .RuleFor(u => u.FirstName, f => f.Name.FirstName(gender))
                .RuleFor(u => u.LastName, f => f.Name.LastName(gender))
                .RuleFor(u => u.ExperienceYears, f => f.Random.Int(1, 10))
                .RuleFor(u => u.Car, f => fakeCars.Generate());

            Drivers = _driversFaker.Generate(10);
        }

        public Driver Generate()
        {
            return _driversFaker.Generate();
        }

        public void SaveChanges()
        {
            // serialize Drivers
        }
    }
}
