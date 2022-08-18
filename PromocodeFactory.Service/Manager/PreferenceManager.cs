using AutoMapper;
using PromocodeFactory.Domain.PromocodeManagement;
using PromocodeFactory.Infrastructure.Interfaces;
using PromocodeFactory.Infrastructure.Interfaces.PromocodeManagment;
using PromocodeFactory.Service.DTO.PromocodeManagment;
using PromocodeFactory.Service.Exceptions;
using PromocodeFactory.Service.Interfaces;

namespace PromocodeFactory.Service.Manager
{
    public class PreferenceManager: IPreferenceManager
    {
        private IPreferenceRepository _repository;
        private IMapper _mapper;
        private ILoggerManager _logger;
       
        public PreferenceManager(IPreferenceRepository repository, IMapper mapper, ILoggerManager logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;        
        }
        public async Task<IEnumerable<PreferenceDTO>> GetAllAsync()
        {
            var preference = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<PreferenceDTO>>(preference);
        }

        public async Task<PreferenceDTO> GetAsync(string name)
        {
            return _mapper.Map<PreferenceDTO>(await _repository.GetAsyncByName(name));
        }

        public async Task CreateAsync(PreferenceDTO preference)
        {
            var preferenceCreate = _mapper.Map<Preference>(preference);
            
            if (await _repository.ExistAsync(c=>c.Name == preferenceCreate.Name))
            {
                _logger.LogInfo($"Preference already exist.");
                throw new PreferenceException($"Preference already exist.");
            }
            
            await _repository.CreateAsync(preferenceCreate);

        }
        public async Task UpdateAsync(PreferenceDTO preference)
        {
            var preferenceMap = _mapper.Map<Preference>(preference);
            var preferenceBd = await _repository.GetAsyncById(preference.PreferenceId);
            if (preferenceBd == null)
            {
                _logger.LogInfo($"Preference does not exist.");
                throw new PreferenceException($"Preference does not exist.");
            }
            
            preferenceBd.Name = preferenceMap.Name;
            await _repository.UpdateAsync(preferenceBd);
        }
        public async Task DeleteAsync(Guid preferenceId)
        {
            var preference = await _repository.FindPreferenceAsync(preferenceId);
            if (preference == null)
            {
                _logger.LogInfo($"Preference does not exist.");
                throw new PreferenceException($"Preference does not exist.");
            }
            await _repository.DeleteAsync(preference);
        }
       
    }
}
