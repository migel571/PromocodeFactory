using Microsoft.EntityFrameworkCore;
using PromocodeFactory.Domain.PromocodeManagement;
using PromocodeFactory.Infrastructure.Interfaces.PromocodeManagment;
using System.Linq.Expressions;


namespace PromocodeFactory.Infrastructure.Repository.PromocodeManagment
{
    public class PreferenceRepository : IPreferenceRepository
    {
        private readonly PromocodeContext _context;

        public PreferenceRepository(PromocodeContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Preference>> GetAllAsync()
        {
            return await _context.Preferences.AsNoTracking().ToListAsync();
        }

        public async Task<Preference> GetAsyncById(Guid preferenceId)
        {
            return await _context.Preferences.Include(p => p.Customers).Include(p => p.PromoCodes).FirstOrDefaultAsync(p => p.PreferenceId == preferenceId);
        }
        public async Task<Preference> GetAsyncByName(string name)
        {
            return await _context.Preferences.Include(p => p.Customers).Include(p => p.PromoCodes).FirstOrDefaultAsync(p => p.Name == name);
        }

        public async Task CreateAsync(Preference preference)
        {
            await _context.Preferences.AddAsync(preference);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Preference preference)
        {
            _context.Preferences.Update(preference);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Preference preference)
        {
            _context.Preferences.Remove(preference);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> ExistAsync(Expression<Func<Preference, bool>> expression)
        {
            return await _context.Preferences.AnyAsync(expression);
        }
        public async Task<List<Preference>> GetPreferencesByIdsAsync(List<Guid> preferenceIds)
        {
            return await _context.Preferences.Where(p => preferenceIds.Contains(p.PreferenceId)).ToListAsync();
        }
        public async Task<Preference> FindPreferenceAsync(Guid preferenceId)
        {
            var preference = await _context.Preferences.FindAsync(preferenceId);
            return preference;

        }

    }
}
