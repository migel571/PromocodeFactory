using PromocodeFactory.Service.DTO.PromocodeManagment;

namespace PromocodeFactory.Service.Interfaces
{
    public interface IPreferenceManager
    {
        Task<IEnumerable<PreferenceDTO>> GetAllAsync();
        Task<PreferenceDTO> GetAsync(string name);
        Task CreateAsync(PreferenceDTO preference,List<Guid> customersIds, List<Guid> promoCodeIds);
        Task UpdateAsync(PreferenceDTO preference,List<Guid> customersIds, List<Guid> promoCodeIds);
        Task DeleteAsync(Guid preferenceId);
    }
}
