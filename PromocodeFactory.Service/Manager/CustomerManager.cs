using AutoMapper;
using PromocodeFactory.Domain.PromocodeManagement;
using PromocodeFactory.Infrastructure.Interfaces.PromocodeManagment;
using PromocodeFactory.Service.DTO.PromocodeManagment;
using PromocodeFactory.Service.Interfaces;

namespace PromocodeFactory.Service.Manager
{
    public class CustomerManager:ICustomerManager
    {
        private IRepositoryCustomer _repository;
        private IMapper _mapper;
        public CustomerManager(IRepositoryCustomer repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CustomerDTO>> GetAllAsync()
        {
            var customers = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<CustomerDTO>>(customers);
        }

        public async Task<IEnumerable<CustomerDTO>> GetAsync(string lastName)
        {
            return _mapper.Map<IEnumerable<CustomerDTO>>(await _repository.GetAsync(lastName));
        }

        public async Task CreateAsync(CustomerDTO customer)
        {
            await _repository.CreateAsync(_mapper.Map<Customer>(customer));
        }
        public async Task UpdateAsync(CustomerDTO customer)
        {
            if (await _repository.ExistAsync(filter => filter.LastName == customer.LastName))
                return;

            await _repository.UpdateAsync(_mapper.Map<Customer>(customer));
        }
        public async Task DeleteAsync(Guid customerId)
        {
            if (await _repository.ExistAsync(filter => filter.CustomerId == customerId))
                return;
            await _repository.DeleteAsync(customerId);
        }



    }
}
