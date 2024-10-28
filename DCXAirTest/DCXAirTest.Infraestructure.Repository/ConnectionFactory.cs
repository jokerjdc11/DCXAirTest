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
                try
                {
                    var sqlConnection = new SqliteConnection(_configuration.GetConnectionString(Constants.FLIGHT_CONNECTION_SQLITE));
                    sqlConnection.Open();
                    return sqlConnection;
                }
                catch (Exception ex)
                {
                    // Maneja el error de conexión, puedes registrar el error o lanzar una excepción personalizada
                    throw new Exception("Error al abrir la conexión a la base de datos: " + ex.Message);
                }
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
