using Microsoft.EntityFrameworkCore;
using PromocodeFactory.Domain.PromocodeManagement;
using PromocodeFactory.Infrastructure.Interfaces.PromocodeManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromocodeFactory.Infrastructure.Repository.PromocodeManagment
{
    public class CustomerRepository : IRepositoryCustomer
    {
        private readonly PromocodeContext _context;
        private readonly DbSet<Customer> _dbSet;
        public CustomerRepository(PromocodeContext context)
        {
            _context = context;
            _dbSet = context.Set<Customer>();
        }
        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Customer> GetAsync(string firstname)
        {
            return await _dbSet.Include(p => p.Preferences).FirstOrDefaultAsync(x => x.FirstName == firstname);
        }
        public async Task CreateAsync(Customer customer)
        {
            await _dbSet.AddAsync(customer);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Customer customer)
        {
            _dbSet.Update(customer);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid customerId)
        {
            var customer = await _dbSet.FindAsync(customerId);
            if (customer == null) return;
            _dbSet.Remove(customer);
            await _context.SaveChangesAsync();

        }


    }
}
