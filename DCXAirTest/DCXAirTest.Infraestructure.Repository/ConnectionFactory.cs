namespace DCXAirTest.Infraestructure.Repository
{
    using System.Data;
    using DCXAirTest.Common.Connections;
    using DCXAirTest.Common.Configuration;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Data.Sqlite;
    using System.Data.SqlClient;

    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public IDbConnection GetConnection
        {
            get
            {
                // Configura la conexión SQLite en memoria
                var sqlConnection = new SqliteConnection();

                sqlConnection.ConnectionString = _configuration.GetConnectionString(Constants.FLIGHT_CONNECTION_MEMORY);
                sqlConnection.Open(); // Abre la conexión inmediatamente
                // Devuelve la conexión en memoria
                return sqlConnection;
            }

        }

        // Conexcion a SQL para pruebas
        //public IDbConnection GetConnection
        //{
        //    get
        //    {
        //        var sqlConnection = new SqlConnection();

        //        if (sqlConnection == null) return null;

        //        sqlConnection.ConnectionString = _configuration.GetConnectionString(Constants.FLIGHT_CONNECTION);
        //        sqlConnection.Open();

        //        return sqlConnection;
        //    }
        //}
    }
}
