﻿using PromocodeFactory.UI.Features;
using PromocodeFactory.UI.Models;

namespace PromocodeFactory.UI.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<PagingResponse<EmployeeModel>> GetAllAsync(PagingParameters employeeParameters);
        Task<EmployeeModel> GetAsync(Guid employeeId);
        //Task UpdateAsync(EmployeeModel employee);
        //Task CreateAsync(EmployeeModel employee);
        //Task DeleteAsync(EmployeeModel employee);
    }
}
