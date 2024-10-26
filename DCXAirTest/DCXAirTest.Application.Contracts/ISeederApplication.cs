namespace DCXAirTest.Application.Contracts
{
    using DCXAirTest.Application.DTO;
    using DCXAirTest.Common;

    public interface ISeederApplication
    { 

        #region Metodo Asincronos
        Task<ResponseOperation<IEnumerable<int>>> setNewFligthsAsync(List<FlightDTO> flights);
        #endregion
    }
}
