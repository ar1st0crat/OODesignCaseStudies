using System.Collections.Generic;

namespace AirportApp.Core
{
    public interface IFlightRepository : IRepository<Flight>
    {
        List<Flight> LoadByDepartureCity(string city);
        List<Flight> LoadByArrivalCity(string city);
    }
}
