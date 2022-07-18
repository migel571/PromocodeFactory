using PromocodeFactory.Service.DTO.PromocodeManagment;

namespace PromocodeFactory.Service.Interfaces
{
    public interface ICustomerManager
    {
        Task<IEnumerable<CustomerDTO>> GetAllAsync();
        Task<CustomerDTO> GetAsync(Guid customerId);
        Task CreateAsync(CustomerDTO customer, List<Guid> preferensIds);
        Task UpdateAsync(CustomerDTO customer, List<Guid> preferensIds, List<Guid> promoCodeIds);
        Task DeleteAsync(Guid customerId);
    }
}
