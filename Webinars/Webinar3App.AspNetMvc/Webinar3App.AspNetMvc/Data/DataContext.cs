using Bogus;
using System.Collections.Generic;
using System.Linq;
using Webinar1App.Entities;

namespace Webinar3App.AspNetMvc.Data
{
    /// <summary>
    /// Эмуляция DbContext из ORM
    /// 
    /// (в контексте нашей CQRS-демонстрации это WRITE-model)
    /// 
    /// </summary>
    public class DataContext
    {
        private readonly Faker<Driver> _driversFaker;

        public List<Driver> Drivers { get; private set; } = new List<Driver>();

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
        }

        public Driver Generate()
        {
            return _driversFaker.Generate();
        }

        public void CreateDriver(Driver driver)
        {
            // Auto-increment logic:

            driver.Id = Drivers.Any() ? Drivers.Max(driver => driver.Id) + 1 : 1;

            Drivers.Add(driver);
        }

        public void SaveChanges()
        {
            // serialize Drivers
        }
    }
}
