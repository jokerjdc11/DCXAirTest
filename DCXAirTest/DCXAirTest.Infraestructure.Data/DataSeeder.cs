namespace DCXAirTest.Infraestructure.Data
{
    using Dapper;
    using DCXAirTest.Common.Configuration;
    using DCXAirTest.Common.Connections;
    using DCXAirTest.Domain.Entity.ValueObject;
    using System.Text.Json;

    public class DataSeeder
    {
        private readonly IConnectionFactory _connectionFactory;

        public DataSeeder(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task SeedDataAsync()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,Constants.MARKET_FOLDER,Constants.MARKET_JSON);

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Archivo JSON no encontrado en la ruta: {filePath}");
            }

            // Lee el archivo JSON
            var jsonData = await File.ReadAllTextAsync(filePath);

            // Deserializa el JSON en una lista de JourneyVO
            var listJourney = JsonSerializer.Deserialize<List<JourneyVO>>(jsonData);

            // Inserta los datos usando un método de transacción similar
            await InsertJourneysAsync(listJourney);
        }

        private async Task InsertJourneysAsync(List<JourneyVO> listJourney)
        {
            using (var conexion = _connectionFactory.GetConnection)
            {

                using (var transaction = conexion.BeginTransaction())
                {
                    try
                    {
                        // Limpiamos la tabla antes de ingresar
                        var sqliteInitialite = @"DELETE FROM Flight; 
                                                DELETE FROM sqlite_sequence WHERE name=@Flight;

                                                DELETE FROM Transport; 
                                                DELETE FROM sqlite_sequence WHERE name=@Transport;";
                        var delParameters = new DynamicParameters();
                        delParameters.Add("@Flight", "Fligth");
                        delParameters.Add("@Transport", "Transport");

                        await conexion.ExecuteScalarAsync<int>(sqliteInitialite, delParameters, transaction);

                        foreach (var flight in listJourney)
                        {
                            var transportSql = @"INSERT INTO Transport (FlightCarrier, FlightNumber)
                                         VALUES (@FlightCarrier, @FlightNumber);
                                         SELECT last_insert_rowid();";

                            var transportParameters = new DynamicParameters();
                            transportParameters.Add("@FlightCarrier", flight.Transport.FlightCarrier);
                            transportParameters.Add("@FlightNumber", flight.Transport.FlightNumber);

                            var transportId = await conexion.ExecuteScalarAsync<int>(transportSql, transportParameters, transaction);

                            var flightSql = @"INSERT INTO Flight (Origin, Destination, Price, TransportId)
                                      VALUES (@Origin, @Destination, @Price, @TransportId);
                                      SELECT last_insert_rowid();";

                            var flightParameters = new DynamicParameters();
                            flightParameters.Add("@Origin", flight.Origin);
                            flightParameters.Add("@Destination", flight.Destination);
                            flightParameters.Add("@Price", flight.Price);
                            flightParameters.Add("@TransportId", transportId);

                            await conexion.ExecuteScalarAsync<int>(flightSql, flightParameters, transaction);
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error al insertar datos desde el archivo JSON: " + ex.Message);
                    }
                }
            }
        }
    }
}
