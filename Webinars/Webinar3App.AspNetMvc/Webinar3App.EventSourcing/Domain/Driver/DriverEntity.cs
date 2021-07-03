using EventFlow.Entities;
using Webinar3App.EventSourcing.Domain.Car;

namespace Webinar3App.EventSourcing.Domain.Driver
{
    public class DriverEntity : Entity<DriverId>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int ExperienceYears { get; private set; }
        public bool IsRemoved { get; private set; }
        public CarId CarId { get; private set; }

        public DriverEntity(DriverId id, string firstname, string lastname, int experienceYears) : base(id)
        {
            FirstName = firstname;
            LastName = lastname;
            ExperienceYears = experienceYears;
            IsRemoved = false;
        }
        
        public DriverEntity() : base(DriverId.New) 
        {
        }

        public void MarkAsRemoved()
        {
            IsRemoved = true;
        }

        public void SetCarWithId(CarId carId)
        {
            CarId = carId;
        }
    }
}
