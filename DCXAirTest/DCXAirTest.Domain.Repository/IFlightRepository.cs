namespace DCXAirTest.Domain.Repository
{
    using DCXAirTest.Domain.Entity.General;

    public interface IFlightRepository
    {
        #region Metodo Asincronos
        Task<IEnumerable<Flight>> GetJourneysOneWayAsync();
        Task<IEnumerable<Flight>> GetJourneysRoundTripAsync();

        #endregion
    }
}
