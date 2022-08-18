using PromocodeFactory.Service.DTO.PromocodeManagment;

namespace PromocodeFactory.Service.Interfaces
{
    public interface IPreferenceManager
    {
        Task<IEnumerable<PreferenceDTO>> GetAllAsync();
        Task<PreferenceDTO> GetAsync(string name);
        Task CreateAsync(PreferenceDTO preference);
        Task UpdateAsync(PreferenceDTO preference);
        Task DeleteAsync(Guid preferenceId);
    }
}
