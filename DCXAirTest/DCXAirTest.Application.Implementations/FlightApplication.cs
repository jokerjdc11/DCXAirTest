namespace DCXAirTest.Application.Implementations
{
    using AutoMapper;
    using DCXAirTest.Application.Contracts;
    using DCXAirTest.Application.DTO;
    using DCXAirTest.Common;
    using DCXAirTest.Common.Configuration;
    using DCXAirTest.Domain.Entity.ValueObject;
    using DCXAirTest.Domain.Interface;
    public class FlightApplication : IFlightApplication
    {
        private readonly IMapper _mapper;
        private readonly IFlightDomain _flightDomain;
        private readonly IAppLogger<IFlightApplication> _appLogger;

        public FlightApplication(
            IFlightDomain flightDomain,
            IMapper mapper,
             IAppLogger<IFlightApplication> appLogger
        )
        {
            _flightDomain = flightDomain;
            _mapper = mapper;
            _appLogger = appLogger;
        }

        public async Task<ResponseOperation<IEnumerable<int>>> GetFligthByOriginAsync(string origin)
        {
            _appLogger.LogInformation("extrayendo una lista de vuelos desde la base de datos");

            var response = new ResponseOperation<IEnumerable<int>>();

            try
            {
                //Mapeo de entidad
                //var listJourneyVO = _mapper.Map<string>(listjourney);

                var idRespuesta = await _flightDomain.GetFligthByOriginAsync(origin);

                var idResponse = _mapper.Map<IEnumerable<int>>(idRespuesta);

                response.Data = idResponse;
                response.Message = Constants.MESSAGE_OK;
                response.SuccessfulResult = Constants.OK;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.SuccessfulResult = Constants.ERROR;
                _appLogger.LogError(ex, "Error en el metodo GetFligthByOriginAsync()");
            }
            return response;
        }
    }
}
