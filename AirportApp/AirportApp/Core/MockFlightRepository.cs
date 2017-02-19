using System.Collections.Generic;
using System.Linq;

namespace AirportApp.Core
{
    public class MockFlightRepository : IRepository<Flight>
    {
        public List<Flight> Load()
        {
            return new List<Flight>
            {
                new Flight { Code="56D", DepartureCity = "Donetsk" },
                new Flight { Code="dfA", DepartureCity = "Moscow" },
                new Flight { Code="poi$", DepartureCity = "Rostov" },
                new Flight { Code="A1D", DepartureCity = "Donetsk" },
                new Flight { Code="xD", DepartureCity = "Donetsk" },
                new Flight { Code="poik", DepartureCity = "Beijing" }
            };
        }

        public List<Flight> LoadByDepartureCity(string city)
        {
            var flights = Load();
            return flights.Where(f => f.DepartureCity == city).ToList();
        }

        public void Save()
        {
        }
    }
}