using Microsoft.EntityFrameworkCore;
using PromocodeFactory.Domain.PromocodeManagement;
using PromocodeFactory.Infrastructure.Interfaces.PromocodeManagment;
using PromocodeFactory.Infrastructure.Pagging;
using System.Linq.Expressions;

namespace PromocodeFactory.Infrastructure.Repository.PromocodeManagment
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly PromocodeContext _context;

        public CustomerRepository(PromocodeContext context)
        {
            _context = context;

        }
        public async Task<PagedList<Customer>> GetAllAsync(PaggingParameters customerParameters)
        {
            return await PagedList<Customer>.ToPageListAsync(_context.Customers.AsNoTracking().OrderBy(r => r.FirstName), customerParameters.PageNumber, customerParameters.PageSize);
        }

        public async Task<Customer> GetAsync(Guid customerId)
        {
            return await _context.Customers.Include(p => p.Preferences).Include(p => p.PromoCodes).FirstOrDefaultAsync(x => x.CustomerId == customerId);
        }
        public async Task CreateAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Customer customer)
        {
            //var customerUp = await GetAsync(customer.LastName, customer.Email);
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
        public async Task<Customer> FindCustomerAsync(Guid customerId)
        {
            return await _context.Customers.FindAsync(customerId);
        }
        public async Task<List<Customer>> GetCustomersByIdsAsync(List<Guid> customersIds)
        {
            var customers = await _context.Customers.Where(c=>customersIds.Contains(c.CustomerId)).ToListAsync();
            return customers;
        }

    }
}
