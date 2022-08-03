using Microsoft.EntityFrameworkCore;
using PromocodeFactory.Domain.Administaration;
using PromocodeFactory.Infrastructure.Interfaces.AdministrationRep;
using System.Linq.Expressions;

namespace PromocodeFactory.Infrastructure.Repository.Administration
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly PromocodeContext _context;

        public EmployeeRepository(PromocodeContext context)
        {
            _context = context;

        }


        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees.AsNoTracking().OrderBy(r => r.FirstName).ToListAsync();
        }

        public async Task<Employee> GetAsync(Guid employeeId)
        {
            return await _context.Employees.AsNoTracking().FirstOrDefaultAsync(t => t.EmployeeId == employeeId);
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

        public async Task DeleteAsync(Employee employee)
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }
       
        public async Task<bool> ExistAsync(Expression<Func<Employee, bool>> expression)
        {
            return await _context.Employees.AnyAsync(expression);
        }
        public async Task<Employee> FindEmployeeAsync(Guid employeeId)
        {
            var employee = await _context.Employees.FindAsync(employeeId);
            return employee;
        }
    }
}
