namespace DCXAirTest.Domain.Core
{
    using AutoMapper;
    using DCXAirTest.Common;
    using DCXAirTest.Domain.Entity.ValueObject;
    using DCXAirTest.Domain.Interface;
    using DCXAirTest.Domain.Repository;
    class FlightDomain : IFlightDomain
    {
        private readonly IMapper _mapper;
        private readonly IFlightRepository _flightRepository;

        public FlightDomain(IMapper mapper, IFlightRepository flightRepository)
        {
            _mapper = mapper;
            _flightRepository = flightRepository;
        }

        public async Task<IEnumerable<int>> GetFligthByOriginAsync(string origin)
        {
            return await _flightRepository.GetFligthByOriginAsync(origin);
        }
    }
}
