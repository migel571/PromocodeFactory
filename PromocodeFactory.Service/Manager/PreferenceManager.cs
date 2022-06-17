using AutoMapper;
using PromocodeFactory.Domain.PromocodeManagement;
using PromocodeFactory.Infrastructure.Interfaces.PromocodeManagment;
using PromocodeFactory.Service.DTO.PromocodeManagment;
using PromocodeFactory.Service.Interfaces;

namespace PromocodeFactory.Service.Manager
{
    public class PreferenceManager: IPreferenceManager
    {
        private IRepositoryPreference _repository;
        private IMapper _mapper;
        public PreferenceManager(IRepositoryPreference repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<PreferenceDTO>> GetAllAsync()
        {
            var preference = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<PreferenceDTO>>(preference);
        }

        public async Task<PreferenceDTO> GetAsync(string Name)
        {
            return _mapper.Map<PreferenceDTO>(await _repository.GetAsync(Name));
        }

        public async Task CreateAsync(PreferenceDTO preference)
        {
            await _repository.CreateAsync(_mapper.Map<Preference>(preference));
        }
        public async Task UpdateAsync(PreferenceDTO preference)
        {
            if (await _repository.ExistAsync(filter => filter.Name == preference.Name))
                return;

            await _repository.UpdateAsync(_mapper.Map<Preference>(preference));
        }
        public async Task DeleteAsync(Guid preferenceId)
        {
            if (await _repository.ExistAsync(filter => filter.PreferenceId == preferenceId))
                return;
            await _repository.DeleteAsync(preferenceId);
        }
    }
}
