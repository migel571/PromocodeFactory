using PromocodeFactory.UI.Features;
using PromocodeFactory.UI.Models;

namespace PromocodeFactory.UI.Interfaces
{
    public interface IPartnerRepository
    {
        Task<PagingResponse<PartnerModel>> GetAllAsync(PagingParameters partnerParametres);
        Task<PartnerModel> GetAsync(Guid partnerId);
        Task CreateAsync(CreatePartnerModel partner);
        Task UpdateAsync(PartnerModel partner);
        Task DeleteAsync(Guid partnerId);
       
    }
}
