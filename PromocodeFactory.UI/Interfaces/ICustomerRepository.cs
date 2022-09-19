using PromocodeFactory.UI.Features;
using PromocodeFactory.UI.Models;

namespace PromocodeFactory.UI.Interfaces
{
    public interface ICustomerRepository
    {
        Task<PagingResponse<CustomerModel>> GetAllAsync(PagingParameters customerParameters);
        Task<CustomerModel> GetAsync(Guid customerId);
        Task CreateAsync(CreateCustomerModel customer);
        Task UpdateAsync(UpdateCustomerModel customer);
        Task DeleteAsync(Guid customerId);
       
    }
}
