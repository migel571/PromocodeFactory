using PromocodeFactory.Service.DTO.Administration;

namespace PromocodeFactory.Service.Interfaces
{
    public interface IEmployeeManager
    {
        Task<IEnumerable<EmployeeDTO>> GetAllAsync();
        Task<EmployeeDTO> GetAsync(Guid employeeId);
        Task CreateAsync(EmployeeDTO employee);
        Task UpdateAsync(EmployeeDTO employee);
        Task DeleteAsync(Guid eployeeId);
    }
}
