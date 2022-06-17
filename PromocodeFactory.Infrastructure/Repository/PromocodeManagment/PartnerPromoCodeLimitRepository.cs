using Microsoft.EntityFrameworkCore;
using PromocodeFactory.Domain.PromocodeManagement;
using PromocodeFactory.Infrastructure.Interfaces.PromocodeManagment;
using System.Linq.Expressions;

namespace PromocodeFactory.Infrastructure.Repository.PromocodeManagment
{
    public class PartnerPromoCodeLimitRepository : IRepositoryPartnerPromoCodeLimit
    {
        private PromocodeContext _context;
        private DbSet<PartnerPromoCodeLimit> _dbSet;
        public PartnerPromoCodeLimitRepository(PromocodeContext context)
        {
            _context = context;
            _dbSet = _context.Set<PartnerPromoCodeLimit>();
        }

        public async Task<IEnumerable<PartnerPromoCodeLimit>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<PartnerPromoCodeLimit> GetAsync(Guid limitId)
        {
            return await _dbSet.FirstOrDefaultAsync(f => f.PartnerPromoCodeLimitId == limitId);
        }
        public async Task CreateAsync(PartnerPromoCodeLimit limit)
        {
            await _dbSet.AddAsync(limit);
            await _context.SaveChangesAsync();
        }
        public async Task UpdetaAsync(PartnerPromoCodeLimit limit)
        {
            _dbSet.Update(limit);
            await _context.SaveChangesAsync();  
        }
        public async Task DeleteAsync(Guid limitId)
        {
            var limit = await GetAsync(limitId);
            if (limit == null) return;
            _dbSet.Remove(limit);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> ExistAsync(Expression<Func<PartnerPromoCodeLimit, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }



    }
}
