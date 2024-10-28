namespace DCXAirTest.Application.Contracts
{
    using DCXAirTest.Application.DTO;
    using DCXAirTest.Common;
    public interface IFlightApplication
    {
        #region Metodo Asincronos
        Task<ResponseOperation<List<JourneyDTO>>> GetJourneysOneWayAsync(string origin, string destination,string currency);
        Task<ResponseOperation<List<JourneyDTO>>> GetJourneysRoundTripAsync(string origin, string destination,string currency);
        #endregion
    }
}
