using System;

namespace AirportApp.Core
{
    public class Flight
    {
        public string Code { get; set; }
        public Company Company { get; set; }            // агрегация, чё
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int? SeatCount { get; set; }
    }
}
