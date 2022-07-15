using Microsoft.EntityFrameworkCore;
using PromocodeFactory.Domain.Administaration;
using PromocodeFactory.Infrastructure.Interfaces.AdministrationRep;
using System.Linq.Expressions;

namespace PromocodeFactory.Infrastructure.Repository.Administration
{
    public class EmployeeRepository : IRepositoryEmployee
    {
        private readonly PromocodeContext _context;
        
        public EmployeeRepository(PromocodeContext context)
        {
            _context = context;
            
        }


        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees.OrderBy(r => r.FirstName).ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetAsync(string lastName)
        {
            return await _context.Employees.Where(t=>t.LastName == lastName).ToListAsync();
        }

        public async Task CreateAsync(Employee employee)
        {
           
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return;
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistAsync(Expression<Func<Employee, bool>> expression)
        {
           return await _context.Employees.AnyAsync(expression);
        }
    }
}
