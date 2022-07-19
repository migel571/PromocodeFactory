using PromocodeFactory.Domain.Administaration;
using System.Linq.Expressions;

namespace PromocodeFactory.Infrastructure.Interfaces.AdministrationRep
{
    public interface IRepositoryEmployee
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee> GetAsync(Guid employeeId);
        Task UpdateAsync(Employee employee);
        Task CreateAsync(Employee employee);
        Task DeleteAsync(Employee employee);
        Task<bool> ExistAsync(Expression<Func<Employee,bool>> expression);
        Task<Employee> FindEmployeeAsync(Guid employeeId);

    }
}
