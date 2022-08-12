using PromocodeFactory.Infrastructure.Pagging;
using PromocodeFactory.Service.DTO.Administration;

namespace PromocodeFactory.Service.Interfaces
{
    public interface IEmployeeManager
    {
        Task<PagedList<EmployeeDTO>> GetAllAsync(PaggingParameters employeeParameters);
        Task<EmployeeDTO> GetAsync(Guid employeeId);
        Task CreateAsync(EmployeeDTO employee);
        Task UpdateAsync(EmployeeDTO employee);
        Task DeleteAsync(Guid eployeeId);
    }
}
