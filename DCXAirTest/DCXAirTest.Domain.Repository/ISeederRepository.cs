
namespace DCXAirTest.Domain.Repository
{
    using DCXAirTest.Domain.Entity.ValueObject;

    public interface ISeederRepository
    {
        #region Metodo Asincronos
        Task<IEnumerable<int>> setNewFligthsAsync(List<JourneyVO> listjourney);

        #endregion
    }
}
