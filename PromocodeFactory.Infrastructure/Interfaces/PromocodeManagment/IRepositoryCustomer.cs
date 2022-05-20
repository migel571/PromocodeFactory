using PromocodeFactory.Domain.PromocodeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromocodeFactory.Infrastructure.Interfaces.PromocodeManagment
{
    public interface IRepositoryCustomer
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> GetAsync(string firstname);
        Task CreateAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(Guid customerId);
    }
}
