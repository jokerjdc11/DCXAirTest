namespace DCXAirTest.Common.Connections
{
    using System.Data;

    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }
}
