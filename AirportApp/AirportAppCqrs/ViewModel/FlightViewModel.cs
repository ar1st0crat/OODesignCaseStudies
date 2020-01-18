using System;

namespace AirportAppCqrs.ViewModel
{
    public class FlightViewModel : ViewModelBase
    {
        public string Code { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int? SeatCount { get; set; }
    }
}
