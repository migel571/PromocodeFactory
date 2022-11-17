using PromocodeFactory.Service.DTO.PromocodeManagment;
using PromocodeFactory.Infrastructure.Paging;

namespace PromocodeFactory.Service.Interfaces
{
    public interface IPromoCodeManager
    {
        Task<PagedList<PromoCodeDTO>> GetAllAsync(PagingParameters promocodeParametres);
        Task<PromoCodeDTO> GetAsync(Guid promoCodeId);
        Task<List<PromoCodeDTO>> GetPromocodeByCustomerIdAsync(Guid customerId);
        Task CreateAsync(PromoCodeDTO promocode, Guid preferenceId);
        Task UpdateAsync(PromoCodeDTO promocode);
        Task DeleteAsync(Guid promocodeId);
    }
}
