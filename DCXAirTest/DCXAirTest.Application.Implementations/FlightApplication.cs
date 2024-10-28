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

        public async Task<ResponseOperation<List<JourneyDTO>>> GetJourneysOneWayAsync(string origin, string destination, string currency)
        {
            _appLogger.LogInformation("Consultando el camino de ida con escalas");

            var response = new ResponseOperation<List<JourneyDTO>>();

            try
            {
                //Mapeo de entidad
                var idRespuesta = await _flightDomain.GetJourneysOneWayAsync(origin, destination, currency);

                var idResponse = _mapper.Map<List<JourneyDTO>>(idRespuesta);

                response.Data = idResponse;
                response.Message = Constants.MESSAGE_OK;
                response.SuccessfulResult = Constants.OK;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.SuccessfulResult = Constants.ERROR;
                _appLogger.LogError(ex, "Error en el metodo GetJourneysOneWayAsync()");
            }
            return response;
        }

        public async Task<ResponseOperation<List<JourneyDTO>>> GetJourneysRoundTripAsync(string origin, string destination, string currency)
        {
            _appLogger.LogInformation("Consultando el camino de ida con escalas");

            var response = new ResponseOperation<List<JourneyDTO>>();

            try
            {
                //Mapeo de entidad
                var idRespuesta = await _flightDomain.GetJourneysRoundTripAsync(origin, destination, currency);

                var idResponse = _mapper.Map<List<JourneyDTO>>(idRespuesta);

                response.Data = idResponse;
                response.Message = Constants.MESSAGE_OK;
                response.SuccessfulResult = Constants.OK;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.SuccessfulResult = Constants.ERROR;
                _appLogger.LogError(ex, "Error en el metodo GetJourneysOneWayAsync()");
            }
            return response;
        }
    }
}
