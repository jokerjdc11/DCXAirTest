
namespace DCXAirTest.Domain.Interface
{
    using DCXAirTest.Common;
    using DCXAirTest.Domain.Entity.ValueObject;

    public interface IFlightDomain
    {
        #region Metodo Asincronoss
        Task<IEnumerable<int>> GetFligthByOriginAsync(string origin);
        #endregion
    }
}
