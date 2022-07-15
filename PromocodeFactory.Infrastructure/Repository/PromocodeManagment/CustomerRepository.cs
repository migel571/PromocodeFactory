using Microsoft.EntityFrameworkCore;
using PromocodeFactory.Domain.PromocodeManagement;
using PromocodeFactory.Infrastructure.Interfaces.PromocodeManagment;
using System.Linq.Expressions;

namespace PromocodeFactory.Infrastructure.Repository.PromocodeManagment
{
    public class CustomerRepository : IRepositoryCustomer
    {
        private readonly PromocodeContext _context;
        
        public CustomerRepository(PromocodeContext context)
        {
            _context = context;
            
        }
        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetAsync(string firstname)
        {
            return await _context.Customers.Include(p => p.Preferences).FirstOrDefaultAsync(x => x.FirstName == firstname);
        }
        public async Task CreateAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid customerId)
        {
            var customer = await _context.Customers.FindAsync(customerId);
            if (customer == null) return;
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

        }
        public async Task<bool> ExistAsync(Expression<Func<Customer, bool>> expression)
        {
            return await _context.Customers.AnyAsync(expression);
        }

    }
}
