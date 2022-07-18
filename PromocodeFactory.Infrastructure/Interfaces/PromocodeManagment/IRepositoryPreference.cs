using PromocodeFactory.Domain.PromocodeManagement;
using System.Linq.Expressions;

namespace PromocodeFactory.Infrastructure.Interfaces.PromocodeManagment
{
    public interface IRepositoryPreference
    {
        Task<IEnumerable<Preference>> GetAllAsync();
        Task<Preference> GetAsync(string name);
        Task CreateAsync(Preference preference);
        Task UpdateAsync(Preference preference);
        Task DeleteAsync(Guid preferenceId);
        Task<bool> ExistAsync(Expression<Func<Preference, bool>> expression);
        Task<List<Preference>> GetPreferencesByIdsAsync(List<Guid> preferenceIds);
    }
}
