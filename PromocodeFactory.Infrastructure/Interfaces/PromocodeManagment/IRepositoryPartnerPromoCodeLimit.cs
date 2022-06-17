using PromocodeFactory.Domain.PromocodeManagement;
using System.Linq.Expressions;

namespace PromocodeFactory.Infrastructure.Interfaces.PromocodeManagment
{
    public  interface IRepositoryPartnerPromoCodeLimit
    {
        Task<IEnumerable<PartnerPromoCodeLimit>> GetAllAsync();
        Task<PartnerPromoCodeLimit> GetAsync(Guid limitId);
        Task CreateAsync(PartnerPromoCodeLimit limit);
        Task UpdetaAsync(PartnerPromoCodeLimit limit);
        Task DeleteAsync(Guid limitId);
        Task<bool> ExistAsync(Expression<Func<PartnerPromoCodeLimit, bool>> expression);
    }
}
