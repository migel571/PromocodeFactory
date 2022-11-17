using PromocodeFactory.Domain.Administaration;
using System.Linq.Expressions;
using PromocodeFactory.Infrastructure.Paging;

namespace PromocodeFactory.Infrastructure.Interfaces.AdministrationRep
{
    public interface IEmployeeRepository
    {
        Task<PagedList<Employee>> GetAllAsync(PagingParameters employeeParametres);
        Task<Employee> GetAsync(Guid employeeId);
        Task UpdateAsync(Employee employee);
        Task CreateAsync(Employee employee);
        Task DeleteAsync(Employee employee);
        Task<bool> ExistAsync(Expression<Func<Employee,bool>> expression);
        Task<Employee> FindEmployeeAsync(Guid employeeId);

    }
}
