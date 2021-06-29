namespace Webinar3App.AspNetMvc.Application.Events
{
    public class DriverCreatedEvent : Event
    {
        public int DriverId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ExperienceYears { get; set; }

        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public string CarNo { get; set; }
        public string CarColor { get; set; }
    }
}
