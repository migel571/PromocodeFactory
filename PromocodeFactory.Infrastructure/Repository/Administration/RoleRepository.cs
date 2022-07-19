using Microsoft.EntityFrameworkCore;
using PromocodeFactory.Domain.Administaration;
using PromocodeFactory.Infrastructure.Interfaces.AdministrationRep;
using System.Linq.Expressions;

namespace PromocodeFactory.Infrastructure.Repository.Administration
{
    public class RoleRepository : IRepositoryRole
    {
        private readonly PromocodeContext _context;

        public RoleRepository(PromocodeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await _context.Roles.OrderBy(o => o.RoleName).ToListAsync();
        }

        public async Task<Role> GetAsync(string roleName)
        {
            return await _context.Roles.Include(i => i.Employees).AsNoTracking().FirstOrDefaultAsync(w => w.RoleName == roleName);

        }

        public async Task CreateAsync(Role role)
        {
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Role role)
        {
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Role role)
        {
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistAsync(Expression<Func<Role, bool>> expression)
        {
            return await _context.Roles.AnyAsync(expression);
        }
        public async Task<Role> FindRoleAsync(Guid roleId)
        {
            return await _context.Roles.FindAsync(roleId);
            
        }

    }
}
