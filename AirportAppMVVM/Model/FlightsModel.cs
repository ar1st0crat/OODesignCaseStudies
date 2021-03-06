﻿using AirportAppMVVM.Model.Domain;
using AirportAppMVVM.Model.Repository;
using System.Collections.Generic;

namespace AirportAppMVVM.Model
{
    public class FlightsModel
    {
        IFlightRepository _repository = new MockFlightRepository();
        public List<Flight> Flights { get; set; }

        public void Load()
        {
            Flights = _repository.Load();
        }

        public void LoadByDepartureCity(string city)
        {
            Flights = _repository.LoadByDepartureCity(city);
        }
    }
}
