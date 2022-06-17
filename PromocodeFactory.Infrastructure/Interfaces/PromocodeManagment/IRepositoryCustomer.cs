using PromocodeFactory.Domain.PromocodeManagement;
using System.Linq.Expressions;

namespace PromocodeFactory.Infrastructure.Interfaces.PromocodeManagment
{
    public interface IRepositoryCustomer
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> GetAsync(string firstname);
        Task CreateAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(Guid customerId);
        Task<bool> ExistAsync(Expression<Func<Customer, bool>> expression);
    }
}
