namespace DCXAirTest.Application.DTO
{
    public class TransportDTO
    {
        public int Id { get; set; }
        public string? FlightCarrier { get; set; }
        public string? FlightNumber { get; set; }
        public virtual ICollection<FlightDTO> Flights { get; set; }
    }
}
