using AutoMapper;
using PromocodeFactory.Domain.PromocodeManagement;
using PromocodeFactory.Infrastructure.Interfaces;
using PromocodeFactory.Infrastructure.Interfaces.PromocodeManagment;
using PromocodeFactory.Infrastructure.Paging;
using PromocodeFactory.Service.DTO.PromocodeManagment;
using PromocodeFactory.Service.Exceptions;
using PromocodeFactory.Service.Interfaces;

namespace PromocodeFactory.Service.Manager
{
    public class CustomerManager : ICustomerManager
    {
        private ICustomerRepository _repository;
        private IPreferenceRepository _repositoryPreference;
        private ILoggerManager _logger;
        private IMapper _mapper;

        public CustomerManager(ICustomerRepository repository, IPreferenceRepository repositoryPreference, IMapper mapper, ILoggerManager logger)
        {
            _repository = repository;
            _repositoryPreference = repositoryPreference;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<PagedList<CustomerDTO>> GetAllAsync(PagingParameters customerParameters)
        {
            var customers = await _repository.GetAllAsync(customerParameters);
            return _mapper.Map<PagedList<CustomerDTO>>(customers);
        }

        public async Task<CustomerDTO> GetAsync(Guid customerId)
        {
            var customer = await _repository.FindCustomerAsync(customerId);
            return _mapper.Map<CustomerDTO>(customer);
        }

        public async Task CreateAsync(CustomerDTO customer, List<Guid> preferensIds)
        {
            var customerCreate = _mapper.Map<Customer>(customer);


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

            customerCreate.Preferences = preferences;
            await _repository.CreateAsync(customerCreate);
        }
        public async Task UpdateAsync(CustomerDTO customer, List<Guid> preferensIds)
        {
            var customerMap = _mapper.Map<Customer>(customer);
            if (await _repository.ExistAsync(c => c.LastName == customer.LastName && c.Email == customer.Email))
            {
                _logger.LogInfo($"Customer already exist.");
                throw new CustomerException($"Customer already exist.");
            }
            var customerBd = await _repository.GetAsync(customer.CustomerId);
            if (customerBd == null)
            {
                _logger.LogInfo($"Customer with email={customerMap.Email} and LastName={customerMap.LastName} does not exist.");
                throw new CustomerException($"Customer does not exist.");
            }
            customerBd.FirstName = customerMap.FirstName;
            customerBd.LastName = customerMap.LastName;
            customerBd.Email = customerMap.Email;

            var preferences = await _repositoryPreference.GetPreferencesByIdsAsync(preferensIds);
            if (!preferences.Any())
            {
                _logger.LogInfo($"Preferences does not exist.");
                throw new CustomerException($"Preferences does not exist.");
            }
            customerBd.Preferences = preferences;

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
        public async Task<CustomerDTO> GetCustomerByEmailAsync(string email)
        {
            var customer = await _repository.GetCustomerByEmailAsync(email);
            if (customer == null)
            {
                _logger.LogInfo($"Customer with email={email}  does not exist.");
                throw new CustomerException($"Customer does not exist.");
            }
            return _mapper.Map<CustomerDTO>(customer);
        }



    }
}
