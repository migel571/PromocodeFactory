using Microsoft.EntityFrameworkCore;
using PromocodeFactory.Domain.PromocodeManagement;
using PromocodeFactory.Infrastructure.Interfaces.PromocodeManagment;
using System.Linq.Expressions;
using PromocodeFactory.Infrastructure.Paging;
using PromocodeFactory.Infrastructure.Repository.RepositoryExtensions;

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
            var partners = await _context.Partners.Search(partnerParametres.SearchTerm).AsNoTracking().OrderBy(r => r.Name).ToListAsync();
            return await PagedList<Partner>.ToPageListAsync(partners, partnerParametres.PageNumber, partnerParametres.PageSize);
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
        public async Task UpdateNubmberPromoCodeAsync(string partnerName)
        {
            var partner = await _context.Partners.Where(x => x.Name.ToLower() == partnerName.ToLower()).FirstAsync();
            partner.NumberIssuedPromoCode -= 1;
            await  UpdateAsync(partner);
        }

    }
}
