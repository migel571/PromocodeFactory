using PromocodeFactory.Infrastructure.Paging;
using PromocodeFactory.Service.DTO.PromocodeManagment;

namespace PromocodeFactory.Service.Interfaces
{
    public interface ICustomerManager
    {
        Task<PagedList<CustomerDTO>> GetAllAsync(PagingParameters customerParameters);
        Task<CustomerDTO> GetAsync(Guid customerId);
        Task CreateAsync(CustomerDTO customer, List<Guid> preferensIds);
        Task UpdateAsync(CustomerDTO customer, List<Guid> preferensIds);
        Task DeleteAsync(Guid customerId);
        Task<CustomerDTO> GetCustomerByEmailAsync(string email);
    }
}
