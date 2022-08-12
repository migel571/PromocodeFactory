using PromocodeFactory.Service.DTO.PromocodeManagment;
using PromocodeFactory.Infrastructure.Pagging;

namespace PromocodeFactory.Service.Interfaces
{
    public interface IPartnerManager
    {
        Task<PagedList<PartnerDTO>> GetAllAsync(PaggingParameters partnerParametres);
        Task<PartnerDTO> GetAsync(string Name);
        Task CreateAsync(PartnerDTO partner);
        Task UpdateAsync(PartnerDTO partner);
        Task DeleteAsync(Guid partnerId);
    }
}
