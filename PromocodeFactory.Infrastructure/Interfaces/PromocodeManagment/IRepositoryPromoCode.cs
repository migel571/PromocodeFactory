using PromocodeFactory.Domain.PromocodeManagement;

namespace PromocodeFactory.Infrastructure.Interfaces.PromocodeManagment
{
    public interface IRepositoryPromoCode
    {
        Task<IEnumerable<PromoCode>> GetAllAsync(); 
        Task<PromoCode> GetAsync(Guid promoCodeId);
        Task CreateAsync(PromoCode promoCode);
        Task UpdateAsync(PromoCode promoCode);
        Task DeleteAsync(Guid promoCodeId);
    }
}
