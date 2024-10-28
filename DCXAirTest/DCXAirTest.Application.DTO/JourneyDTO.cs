namespace DCXAirTest.Application.DTO
{
    public class JourneyDTO
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public decimal Price { get; set; }
        public List<FlightDTO> Flights { get; set; }
    }
}
