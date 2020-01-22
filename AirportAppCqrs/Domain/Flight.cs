using System;

namespace AirportAppCqrs.Domain
{
    public class Flight : IEntity
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public Company Company { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int? SeatCount { get; set; }
    }
}
