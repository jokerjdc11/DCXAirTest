namespace DCXAirTest.Domain.Repository
{
    using DCXAirTest.Domain.Entity.ValueObject;

    public interface IFlightRepository
    {
        #region Metodo Asincronos
        Task<IEnumerable<int>> GetFligthByOriginAsync(string origin);

        #endregion
    }
}
