namespace DCXAirTest.Application.DTO
{
    public class FlightDTO
    {
        public int Id { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public double Price { get; set; }
        public int TransportId { get; set; }
        public virtual TransportDTO Transport { get; set; }
    }
}
