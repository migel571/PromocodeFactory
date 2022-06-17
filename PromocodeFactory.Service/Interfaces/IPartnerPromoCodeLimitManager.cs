using PromocodeFactory.Service.DTO.PromocodeManagment;

namespace PromocodeFactory.Service.Interfaces
{
    public interface IPartnerPromoCodeLimitManager
    {
        Task<IEnumerable<PartnerPromoCodeLimitDTO>> GetAllAsync();
        Task<PartnerPromoCodeLimitDTO> GetAsync(Guid limitId);
        Task CreateAsync(PartnerPromoCodeLimitDTO limit);
        Task UpdateAsync(PartnerPromoCodeLimitDTO limit);
        Task DeleteAsync(Guid limitId);
    }
}
