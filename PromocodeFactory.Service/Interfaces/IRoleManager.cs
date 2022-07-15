using PromocodeFactory.Service.DTO.Administration;

namespace PromocodeFactory.Service.Interfaces
{
    public interface IRoleManager
    {
        Task<IEnumerable<RoleDTO>> GetAllAsync();
        Task<RoleDTO> GetAsync(string roleName);
        Task CreateAsync(RoleDTO role);
        Task UpdateAsync(RoleDTO role);
        Task DeleteAsync(Guid roleId);
    }
}
