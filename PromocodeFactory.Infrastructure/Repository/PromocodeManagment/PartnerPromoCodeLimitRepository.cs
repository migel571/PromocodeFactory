using Microsoft.EntityFrameworkCore;
using PromocodeFactory.Domain.PromocodeManagement;
using PromocodeFactory.Infrastructure.Interfaces.PromocodeManagment;
using System.Linq.Expressions;

namespace PromocodeFactory.Infrastructure.Repository.PromocodeManagment
{
    public class PartnerPromoCodeLimitRepository : IRepositoryPartnerPromoCodeLimit
    {
        private PromocodeContext _context;

        public PartnerPromoCodeLimitRepository(PromocodeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PartnerPromoCodeLimit>> GetAllAsync()
        {
            return await _context.PartnerPromoCodeLimits.ToListAsync();
        }

        public async Task<PartnerPromoCodeLimit> GetAsync(Guid limitId)
        {
            return await _context.PartnerPromoCodeLimits.FirstOrDefaultAsync(f => f.PartnerPromoCodeLimitId == limitId);
        }
        public async Task CreateAsync(PartnerPromoCodeLimit limit)
        {
            await _context.PartnerPromoCodeLimits.AddAsync(limit);
            await _context.SaveChangesAsync();
        }
        public async Task UpdetaAsync(PartnerPromoCodeLimit limit)
        {
            _context.PartnerPromoCodeLimits.Update(limit);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid limitId)
        {
            var limit = await GetAsync(limitId);
            if (limit == null) return;
            _context.PartnerPromoCodeLimits.Remove(limit);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> ExistAsync(Expression<Func<PartnerPromoCodeLimit, bool>> expression)
        {
            return await _context.PartnerPromoCodeLimits.AnyAsync(expression);
        }



    }
}
