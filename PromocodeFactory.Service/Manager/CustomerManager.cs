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
        private IRepositoryCustomer _repository;
        private IRepositoryPreference _repositoryPreference;
        private IRepositoryPromoCode _repositoryPromo;
        private ILoggerManager _logger;
        private IMapper _mapper;

        public CustomerManager(IRepositoryCustomer repository, IRepositoryPreference repositoryPreference,IRepositoryPromoCode repositoryPromo, IMapper mapper, ILoggerManager logger)
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

        public async Task CreateAsync(CustomerDTO customer, List<Guid> preferensIds)
        {
            var filterCustomer = _mapper.Map<Customer>(customer);
            filterCustomer.Preferences = await _repositoryPreference.GetPreferencesByIdsAsync(preferensIds);
            if (await _repository.ExistAsync(c => c.LastName == filterCustomer.LastName && c.Email == filterCustomer.Email))
            {
                _logger.LogInfo($"Customer with email={filterCustomer.Email} and LastName={filterCustomer.LastName} already exist.");
                throw new CustomerException($"Customer already exist.");
            }
            await _repository.CreateAsync(filterCustomer);
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
            customerBd.PromoCodes = await _repositoryPromo.GetPromoCodesByIdsAsync(promoCodeIds);
            customerBd.Preferences = await _repositoryPreference.GetPreferencesByIdsAsync(preferensIds);
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
