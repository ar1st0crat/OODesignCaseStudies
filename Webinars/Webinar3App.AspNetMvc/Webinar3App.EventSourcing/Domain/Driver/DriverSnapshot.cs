using EventFlow.Snapshots;

namespace Webinar3App.EventSourcing.Domain.Driver
{
    public class DriverSnapshot : ISnapshot
    {
        public DriverAggregateState DriverState { get; }

        public DriverSnapshot(DriverAggregateState driverState)
        {
            DriverState = driverState;
        }
    }
}
