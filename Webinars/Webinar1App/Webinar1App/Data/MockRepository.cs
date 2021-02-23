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
        private readonly List<Driver> _drivers = new List<Driver>()
        {
                new Driver
                {
                    Id=1,
                    FirstName = "Ivan",
                    LastName = "Ivanov",
                    ExperienceYears = 10,
                    Car = new Car
                    {
                        Id=1,
                        Make="Ford",
                        Model="Focus",
                        No="a123er",
                        Color = CarColor.Black
                    }
                },
                new Driver
                {
                    Id=2,
                    FirstName = "Petr",
                    LastName = "Petrov",
                    ExperienceYears = 5,
                    Car = new Car
                    {
                        Id=2,
                        Make="Toyota",
                        Model="Lexus",
                        No="x343aa",
                        Color = CarColor.Blue
                    }
                },
                new Driver
                {
                    Id=3,
                    FirstName = "Ivan",
                    LastName = "Ivanov",
                    ExperienceYears = 10,
                    Car = new Car
                    {
                        Id=3,
                        Make="Ford",
                        Model="Focus",
                        No="a123er",
                        Color = CarColor.Black
                    }
                },
                new Driver
                {
                    Id=4,
                    FirstName = "Petr",
                    LastName = "Petrov",
                    ExperienceYears = 5,
                    Car = new Car
                    {
                        Id=4,
                        Make="Toyota",
                        Model="Lexus",
                        No="x343aa",
                        Color = CarColor.Blue
                    }
                }
        };

        public IEnumerable<Driver> GetDrivers()
        {
            return _drivers;
        }

        public void AddDriver(Driver driver)
        {
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
