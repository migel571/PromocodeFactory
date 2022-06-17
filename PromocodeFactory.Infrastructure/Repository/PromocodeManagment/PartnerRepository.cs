using Microsoft.EntityFrameworkCore;
using PromocodeFactory.Domain.PromocodeManagement;
using PromocodeFactory.Infrastructure.Interfaces.PromocodeManagment;
using System.Linq.Expressions;

namespace PromocodeFactory.Infrastructure.Repository.PromocodeManagment
{
    public class PartnerRepository : IRepositoryPartner
    {
        private PromocodeContext _context;
        private DbSet<Partner> _dbSet;
        public PartnerRepository(PromocodeContext context)
        {
            _context = context;
            _dbSet = context.Set<Partner>();

        }

        public async Task<IEnumerable<Partner>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Partner> GetAsync(string name)
        {
            return await _dbSet.Include(i => i.PartnerLimits).FirstOrDefaultAsync(f => f.Name == name);
        }
        public async Task CreateAsync(Partner partner)
        {
            await _dbSet.AddAsync(partner);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid partnerId)
        {
            var partner = await _dbSet.FindAsync(partnerId);
            if (partner == null) return;
            _dbSet.Remove(partner);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Partner partner)
        {
            _dbSet.Update(partner);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> ExistAsync(Expression<Func<Partner, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }
    }
}
