using AirportAppMVP.Model.Domain;
using System.Collections.Generic;

namespace AirportAppMVP.Model.Repository
{
    public interface IFlightRepository : IRepository<Flight>
    {
        List<Flight> LoadByDepartureCity(string city);
        List<Flight> LoadByArrivalCity(string city);
    }
}
