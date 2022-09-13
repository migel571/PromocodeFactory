using Microsoft.EntityFrameworkCore;
using PromocodeFactory.Domain.PromocodeManagement;
using PromocodeFactory.Infrastructure.Interfaces.PromocodeManagment;
using System.Linq.Expressions;
using PromocodeFactory.Infrastructure.Paging;

namespace PromocodeFactory.Infrastructure.Repository.PromocodeManagment
{
    public class PromoCodeRepository : IPromoCodeRepository
    {
        private readonly PromocodeContext _context;
        
        public PromoCodeRepository(PromocodeContext context)
        {
            _context = context;
        }
        public async Task<PagedList<PromoCode>> GetAllAsync(PagingParameters promocodeParametres)
        {
            return await PagedList<PromoCode>.ToPageListAsync(_context.PromoCodes.AsNoTracking().OrderBy(r => r.BeginDate), promocodeParametres.PageNumber, promocodeParametres.PageSize);
        }

        public async Task<PromoCode> GetAsync(string code)
        {
            return await _context.PromoCodes.Include(x=>x.PreferenceId).FirstOrDefaultAsync(t=>t.Code == code);
        }

        public async Task CreateAsync(PromoCode promoCode)
        {
            await _context.PromoCodes.AddAsync(promoCode);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(PromoCode promoCode)
        {
            _context.PromoCodes.Update(promoCode);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(PromoCode promoCode)
        {
            _context.PromoCodes.Remove(promoCode);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> ExistAsync(Expression<Func<PromoCode, bool>> expression)
        {
            return await _context.PromoCodes.AnyAsync(expression);
        }

        public async Task<List<PromoCode>> GetPromoCodesByIdsAsync(List<Guid> promocodeIds)
        {
            return await _context.PromoCodes.Where(p => promocodeIds.Contains(p.PromoCodeId)).ToListAsync();
        }
        public async Task<PromoCode> FindPromoCodeAsync(Guid promoCodeId)
        {
            var promoCode = await _context.PromoCodes.FindAsync(promoCodeId);
            return promoCode;
        }
    }
}
