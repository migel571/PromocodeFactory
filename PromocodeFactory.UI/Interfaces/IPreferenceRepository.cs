using PromocodeFactory.UI.Features;
using PromocodeFactory.UI.Models;

namespace PromocodeFactory.UI.Interfaces
{
    public interface IPreferenceRepository
    {
        Task<PagingResponse<PreferenceModel>> GetAllAsync(PagingParameters preferenceParametres);
        Task<PreferenceModel> GetAsync(Guid preferenceId);
        Task CreateAsync(CreatePreferenceModel preference);
        Task UpdateAsync(PreferenceModel preference);
        Task DeleteAsync(Guid preferenceId);
        Task<List<PreferenceModel>> GetPreferenceByCustomerIdAsync(Guid customerId);
        //Task<List<PreferenceModel>> GetListPreference();
    }
}
