namespace DCXAirTest.Domain.Core
{
    using AutoMapper;
    using DCXAirTest.Domain.Entity.ValueObject;
    using DCXAirTest.Domain.Interface;
    using DCXAirTest.Domain.Repository;

    public class SeederDomain : ISeederDomain
    {
        private readonly IMapper _mapper;
        private readonly ISeederRepository _seederRepository;

        public SeederDomain(IMapper mapper, ISeederRepository seederRepository)
        {
            _mapper = mapper;
            _seederRepository = seederRepository;
        }

        public async Task<IEnumerable<int>> setNewFligthsAsync(List<JourneyVO> listjourney)
        {
            return await _seederRepository.setNewFligthsAsync(listjourney);
        }
    }
}
