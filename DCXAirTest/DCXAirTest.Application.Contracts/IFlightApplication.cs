

namespace DCXAirTest.Application.Contracts
{
    using DCXAirTest.Application.DTO;
    using DCXAirTest.Common;
    public interface IFlightApplication
    {
        #region Metodo Asincronos
        Task<ResponseOperation<IEnumerable<int>>> GetFligthByOriginAsync(string origin);
        #endregion
    }
}
