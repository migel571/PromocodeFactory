using PromocodeFactory.Service.DTO.PromocodeManagment;
using PromocodeFactory.Infrastructure.Pagging;

namespace PromocodeFactory.Service.Interfaces
{
    public interface IPromoCodeManager
    {
        Task<PagedList<PromoCodeDTO>> GetAllAsync(PaggingParameters promocodeParametres);
        Task<PromoCodeDTO> GetAsync(string code);
        Task CreateAsync(PromoCodeDTO promocode, Guid preferenceId);
        Task UpdateAsync(PromoCodeDTO promocode);
        Task DeleteAsync(Guid promocodeId);
    }
}
