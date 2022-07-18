using PromocodeFactory.Domain.PromocodeManagement;
using System.Linq.Expressions;

namespace PromocodeFactory.Infrastructure.Interfaces.PromocodeManagment
{
    public interface IRepositoryPromoCode
    {
        Task<IEnumerable<PromoCode>> GetAllAsync(); 
        Task<PromoCode> GetAsync(string code);
        Task CreateAsync(PromoCode promoCode);
        Task UpdateAsync(PromoCode promoCode);
        Task DeleteAsync(Guid promoCodeId);
        Task<bool> ExistAsync(Expression<Func<PromoCode, bool>> expression);
        Task<List<PromoCode>> GetPromoCodesByIdsAsync(List<Guid> promocodeIds);
    }
}
