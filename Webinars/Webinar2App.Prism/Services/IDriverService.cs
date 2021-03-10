using System.Collections.Generic;
using Webinar1App.Entities;

namespace Webinar1App.Services
{
    interface IDriverService
    {
        IEnumerable<Driver> GetDrivers();

        void AddDriver(Driver driver);
        void RemoveDriver(int driverId);
    }
}