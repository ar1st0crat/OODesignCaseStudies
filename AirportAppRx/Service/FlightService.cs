using AirportAppRx.Data;
using AirportAppRx.Model;
using DynamicData;
using System;
using System.Collections.Generic;
using System.IO;

namespace AirportAppRx.Service
{
    public class FlightService
    {
        public readonly SourceList<Flight> _flightSource = new SourceList<Flight>();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IObservable<IChangeSet<Flight>> Connect()
        {
            _flightSource.AddRange(GetFlights());

            return _flightSource.Connect();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Flight> GetFlights()
        {
            return MockRepository.Flights;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Flight AddRandomFlight()
        {
            var flight = new Flight
            {
                Code = Path.GetRandomFileName().Replace(".", "").Substring(0, 3),
                DepartureCity = "RandomD",
                ArrivalCity = "RandomA"
            };

            MockRepository.Flights.Add(flight);

            _flightSource.Add(flight);

            return flight;
        }
    }
}
