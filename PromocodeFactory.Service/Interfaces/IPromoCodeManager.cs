using PromocodeFactory.Service.DTO.PromocodeManagment;

namespace PromocodeFactory.Service.Interfaces
{
    public interface IPromoCodeManager
    {
        Task<IEnumerable<PromoCodeDTO>> GetAllAsync();
        Task<PromoCodeDTO> GetAsync(string code);
        Task CreateAsync(PromoCodeDTO promocode);
        Task UpdateAsync(PromoCodeDTO promocode);
        Task DeleteAsync(Guid promocodeId);
    }
}
