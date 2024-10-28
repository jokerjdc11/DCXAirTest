namespace DCXAirTest.Domain.Entity.General
{
    public class Flight
    {
        public int Id { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public double Price { get; set; }
        public int TransportId { get; set; }

        public virtual Transport Transport { get; set; }
    }
}
