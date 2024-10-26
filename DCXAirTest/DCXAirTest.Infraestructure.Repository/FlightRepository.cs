namespace DCXAirTest.Infraestructure.Repository
{
    using Dapper;
    using DCXAirTest.Common.Configuration;
    using DCXAirTest.Common.Connections;
    using DCXAirTest.Domain.Repository;
    using System.Collections.Generic;
    using System.Data;

    class FlightRepository : IFlightRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public FlightRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<int>> GetFligthByOriginAsync(string origin)
        {
            using (var conexion = _connectionFactory.GetConnection)
            {
                var parametros = new DynamicParameters();

                var sql = @"SELECT 
                        Id
                        ,Origin
                        ,Destination
                        ,Price
                        ,TransportId
                        from [FLIGHTS_DB].[dbo].[Flight]
                        where Origin = @origin"
                ;

                parametros.Add(name: "origin", value: origin);

                var flight = await conexion.QueryAsync<int>(sql, parametros, commandType: CommandType.Text);

                return flight;
            }
        }
    }
}
