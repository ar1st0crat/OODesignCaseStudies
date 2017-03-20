using AirportAppMVC.Model.Domain;
using System.Linq;
using System.Collections.Generic;

namespace AirportAppMVC.Model.Repository
{
    public class FlightRepository : IRepository<Flight>
    {
        public List<Flight> Load()
        {
            var flights = new List<Flight>();

            // код чтения из файла и заполнения flights

            return flights;
        }

        public List<Flight> LoadByDepartureCity(string city)
        {
            var flights = Load();

            return flights.Where(f => f.DepartureCity == city).ToList();
        } 

        public void Save()
        {
            // код записи в файл!
        }
    }
}
