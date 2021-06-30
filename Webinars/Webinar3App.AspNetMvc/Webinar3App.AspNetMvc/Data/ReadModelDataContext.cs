using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Webinar3App.AspNetMvc.Application.Dto;
using Webinar3App.AspNetMvc.Domain.Aggregates;

namespace Webinar3App.AspNetMvc.Data
{
    /// <summary>
    /// Эмуляция READ-модели
    /// 
    /// READ-модель работает с DTO 
    /// WRITE-модель работает с Entities
    /// 
    /// </summary>
    public class ReadModelDataContext
    {
        private readonly IMapper _mapper;

        public List<DriverDto> Drivers { get; private set; } = new List<DriverDto>();

        public ReadModelDataContext(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void AddDriver(Driver driver)
        {
            var driverDto = _mapper.Map<DriverDto>(driver);
            
            Drivers.Add(driverDto);
        }

        public void RemoveDriver(int driverId)
        {
            var driver = Drivers.FirstOrDefault(d => d.Id == driverId);

            Drivers.Remove(driver);
        }
    }
}
