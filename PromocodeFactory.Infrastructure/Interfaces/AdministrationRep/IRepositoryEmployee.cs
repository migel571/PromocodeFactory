using PromocodeFactory.Domain.Administaration;

namespace PromocodeFactory.Infrastructure.Interfaces.AdministrationRep
{
    public interface IRepositoryEmployee
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee> GetAsync(Guid id);
        Task UpdateAsync(Employee employee);
        Task CreateAsync(Employee employee);
        Task DeleteAsync(Guid id);


    }
}
