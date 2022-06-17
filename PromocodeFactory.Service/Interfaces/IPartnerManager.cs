using PromocodeFactory.Service.DTO.PromocodeManagment;

namespace PromocodeFactory.Service.Interfaces
{
    public interface IPartnerManager
    {
        Task<IEnumerable<PartnerDTO>> GetAllAsync();
        Task<PartnerDTO> GetAsync(string Name);
        Task CreateAsync(PartnerDTO partner);
        Task UpdateAsync(PartnerDTO partner);
        Task DeleteAsync(Guid partnerId);
    }
}
