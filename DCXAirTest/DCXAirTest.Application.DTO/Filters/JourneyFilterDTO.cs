namespace DCXAirTest.Application.DTO.Filters
{
    public class JourneyFilterDTO
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public Enum CurrencyType { get; set; }
        public Enum FlightType { get; set; }
    }
}
