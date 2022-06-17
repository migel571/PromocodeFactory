using PromocodeFactory.Service.DTO.PromocodeManagment;

namespace PromocodeFactory.Service.Interfaces
{
    public interface ICustomerManager
    {
       Task<IEnumerable<CustomerDTO>> GetAllAsync();
        Task<IEnumerable<CustomerDTO>> GetAsync(string lastName);
        Task CreateAsync(CustomerDTO customer);
        Task UpdateAsync(CustomerDTO customer);
        Task DeleteAsync(Guid customerId);
    }
}
