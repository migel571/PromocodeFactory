using AutoMapper;
using PromocodeFactory.Domain.PromocodeManagement;
using PromocodeFactory.Infrastructure.Interfaces;
using PromocodeFactory.Infrastructure.Interfaces.PromocodeManagment;
using PromocodeFactory.Service.DTO.PromocodeManagment;
using PromocodeFactory.Service.Exceptions;
using PromocodeFactory.Service.Interfaces;

namespace PromocodeFactory.Service.Manager
{
    public class CustomerManager : ICustomerManager
    {
        private ICustomerRepository _repository;
        private IPreferenceRepository _repositoryPreference;
        private IPromoCodeRepository _repositoryPromo;
        private ILoggerManager _logger;
        private IMapper _mapper;

        public CustomerManager(ICustomerRepository repository, IPreferenceRepository repositoryPreference,IPromoCodeRepository repositoryPromo, IMapper mapper, ILoggerManager logger)
        {
            _repository = repository;
            _repositoryPreference = repositoryPreference;
            _repositoryPromo = repositoryPromo;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CustomerDTO>> GetAllAsync()
        {
            var customers = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<CustomerDTO>>(customers);
        }

        public async Task<CustomerDTO> GetAsync(Guid customerId)
        {
            var customer = await _repository.FindCustomerAsync(customerId);
            return _mapper.Map<CustomerDTO>(customer);
        }

        public async Task CreateAsync(CustomerDTO customer, List<Guid> preferensIds, List<Guid> promoCodeIds)
        {
            var customerCreate = _mapper.Map<Customer>(customer);

            var promocodes = await _repositoryPromo.GetPromoCodesByIdsAsync(promoCodeIds);
            if (!promocodes.Any())
            {
                _logger.LogInfo($"Promocodes does not exist.");
                throw new CustomerException($"Promocodes does not exist.");
            }
            var preferences = await _repositoryPreference.GetPreferencesByIdsAsync(preferensIds);
            if (!preferences.Any())
            {
                _logger.LogInfo($"Preferences does not exist.");
                throw new CustomerException($"Preferences does not exist.");
            }
            if (await _repository.ExistAsync(c => c.LastName == customerCreate.LastName && c.Email == customerCreate.Email))
            {
                _logger.LogInfo($"Customer with email={customerCreate.Email} and LastName={customerCreate.LastName} already exist.");
                throw new CustomerException($"Customer already exist.");
            }
            customerCreate.PromoCodes = promocodes;
            customerCreate.Preferences = preferences;
            await _repository.CreateAsync(customerCreate);
        }
        public async Task UpdateAsync(CustomerDTO customer, List<Guid> preferensIds, List<Guid> promoCodeIds)
        {
            var customerMap = _mapper.Map<Customer>(customer);
            var customerBd = await _repository.GetAsync(customer.CustomerId);
            if (customerBd == null)
            {
                _logger.LogInfo($"Customer with email={customerMap.Email} and LastName={customerMap.LastName} does not exist.");
                throw new CustomerException($"Customer does not exist.");
            }
            customerBd.FirstName = customerMap.FirstName;
            customerBd.LastName = customerMap.LastName;
            customerBd.Email = customerMap.Email;
            
            var promocodes = await _repositoryPromo.GetPromoCodesByIdsAsync(promoCodeIds);
            if (!promocodes.Any())
            {
                _logger.LogInfo($"Promocodes does not exist.");
                throw new CustomerException($"Promocodes does not exist.");
            }
            customerBd.PromoCodes = promocodes;
            var preferences = await _repositoryPreference.GetPreferencesByIdsAsync(preferensIds);
            if (!preferences.Any())
            {
                _logger.LogInfo($"Preferences does not exist.");
                throw new CustomerException($"Preferences does not exist.");
            }
            customerBd.Preferences = preferences;
            // проверка на существование зачем ?
            await _repository.UpdateAsync(customerBd);
        }
        public async Task DeleteAsync(Guid customerId)
        {
            var customer = await _repository.FindCustomerAsync(customerId);
            if (customer == null)
            {
                _logger.LogInfo($"Failed to delete customer with id={customerId}");
                throw new CustomerException($"Failed to delete customer.");
            }
            await _repository.DeleteAsync(customerId);
        }



    }
}
