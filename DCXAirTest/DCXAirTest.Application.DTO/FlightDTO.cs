namespace DCXAirTest.Application.DTO
{
    public class FlightDTO
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public double Price { get; set; }
        public TransportDTO Transport { get; set; }
    }
}
