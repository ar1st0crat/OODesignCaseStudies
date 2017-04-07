using AirportAppMVC.Model.Domain;
using System.Linq;
using System.Collections.Generic;

namespace AirportAppMVC.Model.Repository
{
    public class FlightRepository : IFlightRepository
    {
        public List<Flight> Load()
        {
            var flights = new List<Flight>();

            // код чтения из файла и заполнения flights

            return flights;
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
            // код записи в файл!
        }
    }
}
