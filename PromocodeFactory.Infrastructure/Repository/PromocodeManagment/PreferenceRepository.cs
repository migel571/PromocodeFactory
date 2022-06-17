using Microsoft.EntityFrameworkCore;
using PromocodeFactory.Domain.PromocodeManagement;
using PromocodeFactory.Infrastructure.Interfaces.PromocodeManagment;
using System.Linq.Expressions;


namespace PromocodeFactory.Infrastructure.Repository.PromocodeManagment
{
    public class PreferenceRepository : IRepositoryPreference
    {
        private readonly PromocodeContext _context;
        private readonly DbSet<Preference> _dbSet;
        public PreferenceRepository(PromocodeContext context)
        {
            _context = context;
            _dbSet = context.Set<Preference>();
        }
        public async Task<IEnumerable<Preference>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Preference> GetAsync(string name)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task CreateAsync(Preference preference)
        {
            await _dbSet.AddAsync(preference);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Preference preference)
        {
            _dbSet.Update(preference);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid preferenceId)
        {
            var preference = await _dbSet.FindAsync(preferenceId);
            if (preference == null) return;
            _dbSet.Remove(preference);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> ExistAsync(Expression<Func<Preference, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }


    }
}
