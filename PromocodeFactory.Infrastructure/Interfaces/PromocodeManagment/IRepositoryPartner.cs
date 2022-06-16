using PromocodeFactory.Domain.PromocodeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromocodeFactory.Infrastructure.Interfaces.PromocodeManagment
{
    public interface IRepositoryPartner
    {
        Task<IEnumerable<Partner>> GetAllAsync();
        Task<Partner> GetAsync(string name);
        Task CreateAsync(Partner partner);
        Task UpdateAsync(Partner partner);
        Task DeleteAsync(Guid partnerId);
    }
}
