using PromocodeFactory.Domain.PromocodeManagement;
using System.Linq.Expressions;

namespace PromocodeFactory.Infrastructure.Interfaces.PromocodeManagment
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> GetAsync(Guid customerId);
        Task CreateAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(Guid customerId);
        Task<bool> ExistAsync(Expression<Func<Customer, bool>> expression);
        Task<Customer> FindCustomerAsync(Guid id);
        Task<List<Customer>> GetCustomersByIdsAsync(List<Guid> customerIds);
    }
}
