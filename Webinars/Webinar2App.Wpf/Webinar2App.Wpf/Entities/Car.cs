namespace Webinar1App.Entities
{
    class Car : IEntity 
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public string No { get; set; }
        public CarColor Color { get; set; }
    }
}
