using PromocodeFactory.Domain.PromocodeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromocodeFactory.Infrastructure.Interfaces.PromocodeManagment
{
    public interface IRepositoryPreference
    {
        Task<IEnumerable<Preference>> GetAllAsync();
        Task<Preference> GetAsync(string name);
        Task CreateAsync(Preference preference);
        Task UpdateAsync(Preference preference);
        Task DeleteAsync(Guid preferenceId);
    }
}
