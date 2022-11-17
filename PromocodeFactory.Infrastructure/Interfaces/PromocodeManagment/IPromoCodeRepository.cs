using PromocodeFactory.Domain.PromocodeManagement;
using System.Linq.Expressions;
using PromocodeFactory.Infrastructure.Paging;

namespace PromocodeFactory.Infrastructure.Interfaces.PromocodeManagment
{
    public interface IPromoCodeRepository
    {
        Task<PagedList<PromoCode>> GetAllAsync(PagingParameters promocodeParametres); 
        Task<PromoCode> GetAsync(Guid promoCodeId);
        Task<List<PromoCode>> GetPromocodeByCustomerIdAsync(Guid customerId);
        Task CreateAsync(PromoCode promoCode);
        Task UpdateAsync(PromoCode promoCode);
        Task DeleteAsync(PromoCode promoCode);
        Task<bool> ExistAsync(Expression<Func<PromoCode, bool>> expression);
        Task<List<PromoCode>> GetPromoCodesByIdsAsync(List<Guid> promocodeIds);
        Task<PromoCode> FindPromoCodeAsync(Guid promoCodeId);
    }
}
