using PromocodeFactory.Infrastructure.Paging;
using PromocodeFactory.Service.DTO.Administration;

namespace PromocodeFactory.Service.Interfaces
{
    public interface IEmployeeManager
    {
        Task<PagedList<EmployeeDTO>> GetAllAsync(PagingParameters employeeParameters);
        Task<EmployeeDTO> GetAsync(Guid employeeId);
        Task CreateAsync(EmployeeDTO employee);
        Task UpdateAsync(EmployeeDTO employee);
        Task DeleteAsync(Guid eployeeId);
    }
}
