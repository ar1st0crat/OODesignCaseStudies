namespace Webinar3App.AspNetMvc.Domain.Events
{
    public class DriverRemovedEvent : Event
    {
        public int DriverId { get; set; }
    }
}
