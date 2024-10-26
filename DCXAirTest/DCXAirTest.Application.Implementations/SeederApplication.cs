
namespace DCXAirTest.Application.Implementations
{
    using AutoMapper;
    using DCXAirTest.Application.Contracts;
    using DCXAirTest.Application.DTO;
    using DCXAirTest.Common;
    using DCXAirTest.Domain.Interface;
    using System.Collections.Generic;

    public class SeederApplication : ISeederApplication
    {
        private readonly IMapper _mapper;
        private readonly IFlightDomain _flightDomain;
        private readonly IAppLogger<ISeederApplication> _appLogger;

        public SeederApplication(
            IFlightDomain flightDomain,
            IMapper mapper,
             IAppLogger<ISeederApplication> appLogger
        )
        {
            _flightDomain = flightDomain;
            _mapper = mapper;
            _appLogger = appLogger;
        }

        public Task<ResponseOperation<IEnumerable<int>>> setNewFligthsAsync(List<FlightDTO> flights)
        {

        }
    }
}
