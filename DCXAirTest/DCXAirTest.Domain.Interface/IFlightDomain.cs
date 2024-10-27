
namespace DCXAirTest.Domain.Interface
{
    using DCXAirTest.Application.DTO;
    using DCXAirTest.Common;
    using DCXAirTest.Domain.Entity.General;

    public interface IFlightDomain
    {
        #region Metodo Asincronoss
        Task<List<Journey>> GetJourneysOneWayAsync(string origin, string destination, string currency);
        Task<List<Journey>> GetJourneysRoundTripAsync(string origin, string destination, string currency);
        #endregion
    }
}
