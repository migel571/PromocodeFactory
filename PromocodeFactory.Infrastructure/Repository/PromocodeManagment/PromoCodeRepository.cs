using Microsoft.EntityFrameworkCore;
using PromocodeFactory.Domain.PromocodeManagement;
using PromocodeFactory.Infrastructure.Interfaces.PromocodeManagment;
using System.Linq.Expressions;

namespace PromocodeFactory.Infrastructure.Repository.PromocodeManagment
{
    public class PromoCodeRepository : IRepositoryPromoCode
    {
        private readonly PromocodeContext _context;
        
        public PromoCodeRepository(PromocodeContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PromoCode>> GetAllAsync()
        {
            return await _context.PromoCodes.ToListAsync();
        }

        public async Task<PromoCode> GetAsync(string code)
        {
            return await _context.PromoCodes.FirstOrDefaultAsync(t=>t.Code == code);
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
        public async Task DeleteAsync(Guid promoCodeId)
        {
            var promoCode = await _context.PromoCodes.FindAsync(promoCodeId);
            if (promoCode == null) return;
            _context.PromoCodes.Remove(promoCode);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> ExistAsync(Expression<Func<PromoCode, bool>> expression)
        {
            return await _context.PromoCodes.AnyAsync(expression);
        }

    }
}
