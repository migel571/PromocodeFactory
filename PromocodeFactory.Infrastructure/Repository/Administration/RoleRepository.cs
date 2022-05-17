using Microsoft.EntityFrameworkCore;
using PromocodeFactory.Domain.Administaration;
using PromocodeFactory.Infrastructure.Interfaces.AdministrationRep;

namespace PromocodeFactory.Infrastructure.Repository.Administration
{
    public class RoleRepository : IRepositoryRole
    {
        private readonly PromocodeContext _context;
        private readonly DbSet<Role> _dbSet;
        public RoleRepository(PromocodeContext context)
        {
            _context = context;
            _dbSet = context.Set<Role>();
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await _dbSet.OrderBy(o=>o.RoleName).ToListAsync();
        }

        public async Task<Role> GetAsync(string roleName)
        {
            return await _dbSet.Where(w => w.RoleName == roleName).FirstOrDefaultAsync();

        }

        public async Task CreateAsync(Role role)
        {
            _dbSet.AddAsync(role);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Role role)
        {
            _dbSet.Update(role);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid roleId)
        {
            var role = await _dbSet.FindAsync(roleId);
            if (role == null)
            {
               return;
               
            }

            _dbSet.Remove(role);
            _context.SaveChangesAsync();
        }
    }
}
