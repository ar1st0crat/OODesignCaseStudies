using System.Collections.Generic;
using Webinar1App.Entities;

namespace Webinar1App.Data
{
    interface IRepository
    {
        IEnumerable<Driver> GetDrivers();

        void AddDriver(Driver driver);
        void RemoveDriver(int id);
    }
}