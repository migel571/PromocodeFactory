using PromocodeFactory.Domain.PromocodeManagement;
using System.Linq.Expressions;

namespace PromocodeFactory.Infrastructure.Interfaces.PromocodeManagment
{
    public interface IPreferenceRepository
    {
        Task<IEnumerable<Preference>> GetAllAsync();
        Task<Preference> GetAsyncById(Guid preferenceId);
        Task<Preference> GetAsyncByName(string name);
        Task CreateAsync(Preference preference);
        Task UpdateAsync(Preference preference);
        Task DeleteAsync(Preference preference);
        Task<bool> ExistAsync(Expression<Func<Preference, bool>> expression);
        Task<List<Preference>> GetPreferencesByIdsAsync(List<Guid> preferenceIds);
        Task<Preference> FindPreferenceAsync(Guid preferenceId);
    }
}
