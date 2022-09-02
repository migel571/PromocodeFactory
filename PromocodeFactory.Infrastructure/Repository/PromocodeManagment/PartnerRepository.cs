using Microsoft.EntityFrameworkCore;
using PromocodeFactory.Domain.PromocodeManagement;
using PromocodeFactory.Infrastructure.Interfaces.PromocodeManagment;
using System.Linq.Expressions;
using PromocodeFactory.Infrastructure.Paging;

namespace PromocodeFactory.Infrastructure.Repository.PromocodeManagment
{
    public class PartnerRepository : IPartnerRepository
    {
        private PromocodeContext _context;
        
        public PartnerRepository(PromocodeContext context)
        {
            _context = context;
        }

        public async Task<PagedList<Partner>> GetAllAsync(PagingParameters partnerParametres)
        {
            return await PagedList<Partner>.ToPageListAsync(_context.Partners.AsNoTracking().OrderBy(r => r.Name), partnerParametres.PageNumber, partnerParametres.PageSize);
        }

        public async Task<Partner> GetAsync(Guid partnerId)
        {
            return await _context.Partners.AsNoTracking().FirstOrDefaultAsync(f => f.PartnerId == partnerId);
        }
        public async Task CreateAsync(Partner partner)
        {
            await _context.Partners.AddAsync(partner);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Partner partner)
        {
            _context.Partners.Update(partner);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid partnerId)
        {
            var partner = await _context.Partners.FindAsync(partnerId);
            if (partner == null) return;
            _context.Partners.Remove(partner);
            await _context.SaveChangesAsync();
        }

        
        public async Task<bool> ExistAsync(Expression<Func<Partner, bool>> expression)
        {
            return await _context.Partners.AnyAsync(expression);
        }
        
    }
}
