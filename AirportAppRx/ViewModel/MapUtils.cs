using AirportAppRx.Model;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;

namespace AirportAppRx.ViewModel
{
    public static class MapUtils
    {
        /// <summary>
        /// Вообще для маппинга есть AutoMapper, но сейчас тоже не об этом )
        /// </summary>
        /// <param name="flights"></param>
        /// <returns></returns>
        public static ICollection<FlightViewModel> ToViewModels(this ICollection<Flight> flights)
        {
            return flights.Select(f => new FlightViewModel
            {
                Code = f.Code,
                ArrivalCity = f.ArrivalCity,
                DepartureCity = f.DepartureCity
            })
            .ToList();
        }

        public static FlightViewModel ToViewModel(this Flight flight)
        {
            return new FlightViewModel
            {
                Code = flight.Code,
                ArrivalCity = flight.ArrivalCity,
                DepartureCity = flight.DepartureCity
            };
        }
    }
}
