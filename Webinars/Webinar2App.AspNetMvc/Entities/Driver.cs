namespace Webinar1App.Entities
{
    public class Driver : IEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ExperienceYears { get; set; }

        public Car Car { get; set; }
    }
}
