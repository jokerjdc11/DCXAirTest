namespace DCXAirTest.Domain.Entity.General
{
    public class Transport
    {
        public int Id { get; set; }
        public string? FlightCarrier { get; set; }
        public string? FlightNumber { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
    }
}
