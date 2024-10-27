namespace DCXAirTest.Common
{
    using AutoMapper;
    using DCXAirTest.Application.DTO;
    using DCXAirTest.Domain.Entity.General;
    using DCXAirTest.Domain.Entity.ValueObject;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Flight, FlightDTO>().ReverseMap();
            CreateMap<Transport, TransportDTO>().ReverseMap();
            CreateMap<Journey, JourneyDTO>().ReverseMap();
        }
    }
}
