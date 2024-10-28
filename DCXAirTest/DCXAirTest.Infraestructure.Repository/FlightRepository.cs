namespace DCXAirTest.Infraestructure.Repository
{
    using Dapper;
    using DCXAirTest.Common.Connections;
    using DCXAirTest.Domain.Entity.General;
    using DCXAirTest.Domain.Repository;

    public class FlightRepository : IFlightRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public FlightRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Flight>> GetJourneysOneWayAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var Flights = @"SELECT 
                                    f.Origin,
                                    f.Destination,
                                    f.price,
                                    t.FlightCarrier,
                                    t.FlightNumber
                                    FROM Flight as f
                                    INNER JOIN Transport as t ON  f.TransportId = t.TransportId;";


                        var totalFlight = await connection.QueryAsync<Flight, Transport, Flight>(Flights,
                        (flight, transport) =>
                        {
                            flight.Transport = transport;
                            return flight;
                        },
                        transaction: transaction,
                        splitOn: "FlightCarrier");
                        //continue
                        transaction.Commit();
                        return totalFlight;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback(); // Revertir en caso de error
                        throw new Exception("Error al obtener los vuelos " + ex.Message);
                    }
                }
            }
        }

        public async Task<IEnumerable<Flight>> GetJourneysRoundTripAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var Flights = @"SELECT 
                                    f.Origin,
                                    f.Destination,
                                    f.price,
                                    t.FlightCarrier,
                                    t.FlightNumber
                                    FROM Flight as f
                                    INNER JOIN Transport as t ON  f.TransportId = t.TransportId;";


                        var totalFlight = await connection.QueryAsync<Flight, Transport, Flight>(Flights,
                        (flight, transport) =>
                        {
                            flight.Transport = transport;
                            return flight;
                        },
                        transaction: transaction,
                        splitOn: "FlightCarrier");
                        //continue
                        transaction.Commit();
                        return totalFlight;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback(); // Revertir en caso de error
                        throw new Exception("Error al obtener los vuelos " + ex.Message);
                    }
                }
            }
        }
    }
}


