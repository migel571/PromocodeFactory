using PromocodeFactory.Domain.Administaration;

namespace PromocodeFactory.Infrastructure.Interfaces.AdministrationRep
{
    public interface IRepositoryRole
    {
        Task<IEnumerable<Role>> GetAllAsync();
        Task<Role> GetAsync(string roleName);
        Task CreateAsync(Role role);
        Task UpdateAsync(Role role);
        Task DeleteAsync(Guid roleId);
    }
}
