namespace Webinar3App.AspNetMvc.Application.Events
{
    public class DriverRemovedEvent : Event
    {
        public int DriverId { get; set; }
    }
}
