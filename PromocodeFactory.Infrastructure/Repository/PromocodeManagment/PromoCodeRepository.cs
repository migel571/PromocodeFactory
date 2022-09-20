using Microsoft.EntityFrameworkCore;
using PromocodeFactory.Domain.PromocodeManagement;
using PromocodeFactory.Infrastructure.Interfaces.PromocodeManagment;
using System.Linq.Expressions;
using PromocodeFactory.Infrastructure.Paging;
using PromocodeFactory.Infrastructure.Repository.RepositoryExtensions;

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
            var promoCodes = await _context.PromoCodes.Search(promocodeParametres.SearchTerm).AsNoTracking().OrderBy(r => r.BeginDate).ToListAsync();
            return await PagedList<PromoCode>.ToPageListAsync(promoCodes, promocodeParametres.PageNumber, promocodeParametres.PageSize);
        }

        public async Task<PromoCode> GetAsync(Guid promoCodeId)
        {
            return await _context.PromoCodes.FirstOrDefaultAsync(t=>t.PromoCodeId == promoCodeId);
        }
        public async Task<List<PromoCode>> GetPromocodeByCustomerIdAsync(Guid customerId)
        {
            return await _context.Customers.Where(x=>x.CustomerId == customerId).Select(x=>x.PromoCodes.ToList()).FirstOrDefaultAsync();
        }
        public async Task CreateAsync(PromoCode promoCode)
        {
            
            var customers = await  _context.Preferences.Where(p => p.PreferenceId == promoCode.PreferenceId).Select(x => x.Customers).FirstAsync();
            promoCode.Customers = customers;
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
