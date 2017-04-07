using AirportAppMVVM.Model.Domain;
using System.Collections.Generic;

namespace AirportAppMVVM.Model.Repository
{
    public interface IFlightRepository : IRepository<Flight>
    {
        List<Flight> LoadByDepartureCity(string city);
        List<Flight> LoadByArrivalCity(string city);
    }
}
