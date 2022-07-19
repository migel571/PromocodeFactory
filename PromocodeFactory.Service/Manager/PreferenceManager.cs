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
        private IRepositoryPreference _repository;
        private IRepositoryCustomer _repositoryCustomer;
        private IRepositoryPromoCode _repositoryPromo;
        private IMapper _mapper;
        private ILoggerManager _logger;
       
        public PreferenceManager(IRepositoryPreference repository, IRepositoryCustomer repositoryCustomer, IRepositoryPromoCode repositoryPromo, IMapper mapper, ILoggerManager logger)
        {
            _repository = repository;
            _repositoryCustomer = repositoryCustomer;
            _repositoryPromo = repositoryPromo; 
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

        public async Task CreateAsync(PreferenceDTO preference, List<Guid> customersIds, List<Guid> promoCodeIds)
        {
            var preferenceCreate = _mapper.Map<Preference>(preference);
            var customers  = await _repositoryCustomer.GetCustomersByIdsAsync(customersIds);
            if (!customers.Any())
            {
                _logger.LogInfo($"Customers does not exist.");
                throw new PreferenceException($"Customers does not exist.");
            }
            var promoCodes = await _repositoryPromo.GetPromoCodesByIdsAsync(promoCodeIds);
            if (!promoCodes.Any())
            {
                _logger.LogInfo($"Promocodes does not exist.");
                throw new PreferenceException($"Promocodes does not exist.");
            }
            if (await _repository.ExistAsync(c=>c.Name == preferenceCreate.Name))
            {
                _logger.LogInfo($"Preference already exist.");
                throw new PreferenceException($"Preference already exist.");
            }
            preferenceCreate.PromoCodes = promoCodes;
            preferenceCreate.Customers = customers;
            await _repository.CreateAsync(preferenceCreate);

        }
        public async Task UpdateAsync(PreferenceDTO preference, List<Guid> customersIds, List<Guid> promoCodeIds)
        {
            var preferenceMap = _mapper.Map<Preference>(preference);
            var preferenceBd = await _repository.GetAsyncById(preference.PreferenceId);
            if (preferenceBd == null)
            {
                _logger.LogInfo($"Preference does not exist.");
                throw new PreferenceException($"Preference does not exist.");
            }
            var customers = await _repositoryCustomer.GetCustomersByIdsAsync(customersIds);
            if (!customers.Any())
            {
                _logger.LogInfo($"Customers does not exist.");
                throw new PreferenceException($"Customers does not exist.");
            }
            var promoCodes = await _repositoryPromo.GetPromoCodesByIdsAsync(promoCodeIds);
            if (!promoCodes.Any())
            {
                _logger.LogInfo($"Promocodes does not exist.");
                throw new PreferenceException($"Promocodes does not exist.");
            }
            preferenceBd.Name = preferenceMap.Name;
            preferenceBd.PromoCodes = promoCodes;
            preferenceBd.Customers = customers;

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
