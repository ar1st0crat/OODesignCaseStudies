using EventFlow.Core;

namespace Webinar3App.EventSourcing.Domain.Driver
{
    public class DriverId : Identity<DriverId>
    {
        public DriverId(string value) : base(value) { }
    }
}
