using PromocodeFactory.Domain.Administaration;
using System.Linq.Expressions;

namespace PromocodeFactory.Infrastructure.Interfaces.AdministrationRep
{
    public interface IRepositoryRole
    {
        Task<IEnumerable<Role>> GetAllAsync();
        Task<Role> GetAsync(string roleName);
        Task CreateAsync(Role role);
        Task UpdateAsync(Role role);
        Task DeleteAsync(Role role);
        Task<bool> ExistAsync(Expression<Func<Role,bool>> expression);
        Task<Role> FindRoleAsync(Guid roleId);
    }
}
