namespace DCXAirTest.Infraestructure.Repository
{
    using Dapper;
    using DCXAirTest.Common.Connections;
    using DCXAirTest.Domain.Entity.ValueObject;
    using DCXAirTest.Domain.Repository;
    using System.Collections.Generic;
    using System.Data;

    public class SeederRepository : ISeederRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public SeederRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<int>> setNewFligthsAsync(List<JourneyVO> listjourney)
        {
            using (var conexion = _connectionFactory.GetConnection)
            {
                var flightRes = new List<int>();
                using (var transaction = conexion.BeginTransaction())
                {
                    try
                    {
                        foreach (var flight in listjourney)
                        {
                            // Inserta en la tabla Transport
                            var transportSql = @"INSERT INTO Transport (FlightCarrier, FlightNumber)
                                            VALUES (@FlightCarrier, @FlightNumber);
                                            SELECT last_insert_rowid();";

                            var transportParameters = new DynamicParameters();
                            transportParameters.Add("@FlightCarrier", flight.Transport.FlightCarrier);
                            transportParameters.Add("@FlightNumber", flight.Transport.FlightNumber);

                            // Obtiene el ID del transporte insertado
                            var transportId = await conexion.QuerySingleAsync<int>(transportSql, transportParameters, transaction: transaction, commandType: CommandType.Text);

                            // Inserta en la tabla Flight usando el TransportId
                            var flightSql = @"INSERT INTO Flight (Origin, Destination, Price, TransportId)
                                        VALUES (@Origin, @Destination, @Price, @TransportId);";

                            var flightParameters = new DynamicParameters();
                            flightParameters.Add("@Origin", flight.Origin);
                            flightParameters.Add("@Destination", flight.Destination);
                            flightParameters.Add("@Price", flight.Price);
                            flightParameters.Add("@TransportId", transportId); // Usa el ID del transporte insertado

                            // Ejecuta la inserción en Flight
                            var flightId = await conexion.QuerySingleAsync<int>(flightSql, flightParameters, transaction: transaction, commandType: CommandType.Text);
                            flightRes.Add(flightId); // Agrega el FlightId a la lista de resultados
                        }
                        transaction.Commit(); // Confirma la transacción
                        return flightRes;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback(); // Revertir en caso de error
                        throw new Exception("Error al insertar vuelos y transportes: " + ex.Message);
                    }
                }

            }
        }
    }
}
