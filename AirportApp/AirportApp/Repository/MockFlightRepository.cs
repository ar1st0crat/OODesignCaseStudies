using System.Collections.Generic;
using System.Linq;

namespace AirportApp.Core
{
    public class MockFlightRepository : IFlightRepository
    {
        public List<Flight> Load()
        {
            return new List<Flight>
            {
                new Flight { Code="56D", DepartureCity = "Donetsk", ArrivalCity="Kazan'" },
                new Flight { Code="dfA", DepartureCity = "Moscow", ArrivalCity="Amsterdam" },
                new Flight { Code="poi$", DepartureCity = "Rostov", ArrivalCity="Ufa" },
                new Flight { Code="A1D", DepartureCity = "Donetsk", ArrivalCity="Burgas" },
                new Flight { Code="xD", DepartureCity = "Donetsk", ArrivalCity="Istanbul" },
                new Flight { Code="poik", DepartureCity = "Beijing", ArrivalCity="Berlin" }
            };
        }

        public List<Flight> LoadByDepartureCity(string city)
        {
            return Load().Where(f => f.DepartureCity == city).ToList();
        }

        public List<Flight> LoadByArrivalCity(string city)
        {
            return Load().Where(f => f.ArrivalCity == city).ToList();
        }

        public void Save()
        {
        }
    }
}