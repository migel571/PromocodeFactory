using PromocodeFactory.Infrastructure.Pagging;
using PromocodeFactory.Service.DTO.PromocodeManagment;

namespace PromocodeFactory.Service.Interfaces
{
    public interface ICustomerManager
    {
        Task<PagedList<CustomerDTO>> GetAllAsync(PaggingParameters customerParameters);
        Task<CustomerDTO> GetAsync(Guid customerId);
        Task CreateAsync(CustomerDTO customer, List<Guid> preferensIds, List<Guid> promoCodeIds);
        Task UpdateAsync(CustomerDTO customer, List<Guid> preferensIds, List<Guid> promoCodeIds);
        Task DeleteAsync(Guid customerId);
    }
}
