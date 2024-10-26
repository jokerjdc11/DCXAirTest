namespace DCXAirTest.Domain.Entity.ValueObject
{
    using DCXAirTest.Domain.Entity.General;

    public class JourneyVO
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public double Price { get; set; }

        public Transport Transport { get; set; }
    }
}
