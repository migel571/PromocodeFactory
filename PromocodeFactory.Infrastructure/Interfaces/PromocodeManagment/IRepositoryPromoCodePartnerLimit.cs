using PromocodeFactory.Domain.PromocodeManagement;

namespace PromocodeFactory.Infrastructure.Interfaces.PromocodeManagment
{
    public  interface IRepositoryPromoCodePartnerLimit
    {
        Task<IEnumerable<PartnerPromoCodeLimit>> GetAllAsync();
        Task<PartnerPromoCodeLimit> GetAsync(Guid limitId);
        Task CreateAsync(PartnerPromoCodeLimit limit);
        Task UpdetaAsync(PartnerPromoCodeLimit limit);
        Task DeleteAsync(Guid limitId);

    }
}
