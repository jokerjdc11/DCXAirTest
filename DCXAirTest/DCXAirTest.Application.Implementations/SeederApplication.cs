namespace DCXAirTest.Application.Implementations
{
    using AutoMapper;
    using DCXAirTest.Application.Contracts;
    using DCXAirTest.Application.DTO;
    using DCXAirTest.Common;
    using DCXAirTest.Common.Configuration;
    using DCXAirTest.Domain.Entity.ValueObject;
    using DCXAirTest.Domain.Interface;
    using System.Collections.Generic;

    public class SeederApplication : ISeederApplication
    {
        private readonly ISeederDomain _seederDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<ISeederApplication> _appLogger;

        public SeederApplication(
            ISeederDomain seederDomain,
            IMapper mapper,
             IAppLogger<ISeederApplication> appLogger
        )
        {
            _seederDomain = seederDomain;
            _mapper = mapper;
            _appLogger = appLogger;
        }

        public async Task<ResponseOperation<IEnumerable<int>>> setNewFligthsAsync(List<FlightDTO> listFlights)
        {
            _appLogger.LogInformation("Agregando una lista seeder de vuelos a la base de datos...");

            var response = new ResponseOperation<IEnumerable<int>>();

            try
            {
                //Mapeo de entidad
                var listJourneyVO = _mapper.Map<List<JourneyVO>>(listFlights);

                var idRespuesta = await _seederDomain.setNewFligthsAsync(listJourneyVO);
                // Logica del aplicativo
                var idResponse = _mapper.Map<IEnumerable<int>>(idRespuesta);

                response.Data = idResponse;
                response.Message = Constants.MESSAGE_OK;
                response.SuccessfulResult = Constants.OK;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.SuccessfulResult = Constants.ERROR;
                _appLogger.LogError(ex, "Errror en el metodo para obtener los vuelos");
            }
            return response;

        }
    }
}
