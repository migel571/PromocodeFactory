using Microsoft.EntityFrameworkCore;
using PromocodeFactory.Domain.PromocodeManagement;
using PromocodeFactory.Infrastructure.Interfaces.PromocodeManagment;
using PromocodeFactory.Infrastructure.Paging;
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
        public async Task<PagedList<Preference>> GetAllAsync(PagingParameters employeeParametres)
        {
            return await PagedList<Preference>.ToPageListAsync(_context.Preferences.AsNoTracking().OrderBy(r => r.Name), employeeParametres.PageNumber, employeeParametres.PageSize);
        }

        public async Task<Preference> GetAsyncById(Guid preferenceId)
        {
            return await _context.Preferences.FirstOrDefaultAsync(p => p.PreferenceId == preferenceId);
        }
        public async Task<Preference> GetAsyncByName(string name)
        {
            return await _context.Preferences.FirstOrDefaultAsync(p => p.Name == name);
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

        public async Task<List<Preference>> FindPreferenceByIdCustomerAsync(Guid customerId)
        {
            var preferences = await _context.Customers.Where(x => x.CustomerId == customerId).Include(x=>x.Preferences).Select(x => x.Preferences).FirstAsync();
            return preferences.ToList();
        }
    }
}
