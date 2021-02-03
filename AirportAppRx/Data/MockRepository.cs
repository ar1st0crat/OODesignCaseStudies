using AirportAppRx.Model;
using System.Collections.Generic;

namespace AirportAppRx.Data
{
    public static class MockRepository
    {
        public static List<Flight> Flights { get; set; } = new List<Flight>()
        {
            new Flight { Id = 1, Code="56D", DepartureCity = "Donetsk", ArrivalCity="Kazan'" },
            new Flight { Id = 2, Code="dfA", DepartureCity = "Moscow", ArrivalCity="Amsterdam" },
            new Flight { Id = 3, Code="poi$", DepartureCity = "Rostov", ArrivalCity="Ufa" },
            new Flight { Id = 4, Code="A1D", DepartureCity = "Donetsk", ArrivalCity="Burgas" },
            new Flight { Id = 5, Code="xD", DepartureCity = "Donetsk", ArrivalCity="Istanbul" },
            new Flight { Id = 6, Code="poik", DepartureCity = "Beijing", ArrivalCity="Berlin" }
        };

        public static List<Company> Companies { get; set; } = new List<Company>()
        {
            new Company { Id = 1, Name = "Aero", Rate = 10 },
            new Company { Id = 2, Name = "Air", Rate = 9 }
        };
    }
}
