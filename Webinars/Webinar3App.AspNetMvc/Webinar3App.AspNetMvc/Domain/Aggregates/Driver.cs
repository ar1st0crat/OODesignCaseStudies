using Webinar3App.AspNetMvc.Domain.Entities;

namespace Webinar3App.AspNetMvc.Domain.Aggregates
{
    public class Driver : Aggregate
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ExperienceYears { get; set; }

        public Car Car { get; set; }

        public void ChangeCar(Car car)
        {
            // ...
        }
    }
}
