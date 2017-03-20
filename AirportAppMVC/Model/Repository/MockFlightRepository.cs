using AirportAppMVC.Model.Domain;
using System.Collections.Generic;
using System.Linq;

namespace AirportAppMVC.Model.Repository
{
    public class MockFlightRepository : IRepository<Flight>
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
            var flights = Load();
            return flights.Where(f => f.DepartureCity == city).ToList();
        }

        public void Save()
        {
        }
    }
}