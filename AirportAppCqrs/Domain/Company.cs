namespace AirportAppCqrs.Domain
{
    public class Company : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Rate { get; set; }
    }
}
