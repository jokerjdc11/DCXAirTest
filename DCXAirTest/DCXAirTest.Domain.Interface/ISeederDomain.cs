
namespace DCXAirTest.Domain.Interface
{
    using DCXAirTest.Domain.Entity.ValueObject;

    public interface ISeederDomain
    {
        #region Metodo Asincronoss
        Task<IEnumerable<int>> setNewFligthsAsync(List<JourneyVO> listjourney);

        #endregion
    }
}
