using AirportAppMVC.Model.Domain;
using AirportAppMVC.Model.Repository;
using System;
using System.Collections.Generic;

namespace AirportAppMVC.Model
{
    public class FlightsModel
    {
        IRepository<Flight> _repository = new MockFlightRepository();
        public List<Flight> Flights { get; set; }

        // событие, которое будет поднято при любой новой загрузке рейсов
        public event EventHandler FlightsLoaded;

        public void Load()
        {
            Flights = _repository.Load();
            FlightsLoaded(this, null);
        }

        public void LoadByDepartureCity(string city)
        {
            Flights = _repository.LoadByDepartureCity(city);
            FlightsLoaded(this, null);
        }
    }
}
