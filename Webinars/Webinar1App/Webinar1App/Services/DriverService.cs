using System.Collections.Generic;
using Webinar1App.Data;
using Webinar1App.Entities;

namespace Webinar1App.Services
{
    class DriverService : IDriverService
    {
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork();
        private readonly IRepository _repository;

        public DriverService()
        {
            _repository = _unitOfWork.Repository;
        }

        public IEnumerable<Driver> GetDrivers()
        {
            return _repository.GetDrivers();
        }

        public void AddDriver(Driver driver)
        {
            // validate ...

            _repository.AddDriver(driver);
            _unitOfWork.SaveChanges();
        }

        public void RemoveDriver(int driverId)
        {
            _repository.RemoveDriver(driverId);
            _unitOfWork.SaveChanges();
        }
    }
}
