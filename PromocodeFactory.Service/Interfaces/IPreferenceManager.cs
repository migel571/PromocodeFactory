using PromocodeFactory.Infrastructure.Paging;
using PromocodeFactory.Service.DTO.PromocodeManagment;

namespace PromocodeFactory.Service.Interfaces
{
    public interface IPreferenceManager
    {
        Task<PagedList<PreferenceDTO>> GetAllAsync(PagingParameters preferenceParameters);
        Task<PreferenceDTO> GetAsync(Guid preferenceId);
        Task CreateAsync(PreferenceDTO preference);
        Task UpdateAsync(PreferenceDTO preference);
        Task DeleteAsync(Guid preferenceId);
        Task<List<PreferenceDTO>> GetPreferencesByCustomerIdAsync(Guid preferenceIds);

    }
}
