using Microsoft.EntityFrameworkCore;
using PromocodeFactory.Domain.PromocodeManagement;
using PromocodeFactory.Infrastructure.Interfaces.PromocodeManagment;
using System.Linq.Expressions;

namespace PromocodeFactory.Infrastructure.Repository.PromocodeManagment
{
    public class PartnerRepository : IRepositoryPartner
    {
        private PromocodeContext _context;
        
        public PartnerRepository(PromocodeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Partner>> GetAllAsync()
        {
            return await _context.Partners.ToListAsync();
        }

        public async Task<Partner> GetAsync(string name)
        {
            return await _context.Partners.Include(i => i.PartnerLimits).FirstOrDefaultAsync(f => f.Name == name);
        }
        public async Task CreateAsync(Partner partner)
        {
            await _context.Partners.AddAsync(partner);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid partnerId)
        {
            var partner = await _context.Partners.FindAsync(partnerId);
            if (partner == null) return;
            _context.Partners.Remove(partner);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Partner partner)
        {
            _context.Partners.Update(partner);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> ExistAsync(Expression<Func<Partner, bool>> expression)
        {
            return await _context.Partners.AnyAsync(expression);
        }
    }
}
