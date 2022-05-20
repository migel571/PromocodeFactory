using Microsoft.EntityFrameworkCore;
using PromocodeFactory.Domain.Administaration;
using PromocodeFactory.Infrastructure.Interfaces.AdministrationRep;

namespace PromocodeFactory.Infrastructure.Repository.Administration
{
    public class EmployeeRepository : IRepositoryEmployee
    {
        private readonly PromocodeContext _dbContext;
        private readonly DbSet<Employee> _dbSet;
        public EmployeeRepository(PromocodeContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<Employee>();

        }


        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _dbSet.OrderBy(r => r.FirstName).ToListAsync();
        }

        public async Task<Employee> GetAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task CreateAsync(Employee employee)
        {
            await _dbSet.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Employee employee)
        {
            _dbSet.Update(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var employee = await _dbSet.FindAsync(id);
            if (employee == null)
            {
                return;
            }

            _dbSet.Remove(employee);
            await _dbContext.SaveChangesAsync();
        }
    }
}
