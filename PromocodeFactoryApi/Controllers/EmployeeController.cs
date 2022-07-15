using AutoMapper;
using HybridModelBinding;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromocodeFactory.Infrastructure.Interfaces;
using PromocodeFactory.Service.DTO.Administration;
using PromocodeFactory.Service.Interfaces;
using PromocodeFactoryApi.Commands;

namespace PromocodeFactoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeManager _manager;
        private readonly IMapper _mapper;
        
        public EmployeeController(IEmployeeManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;

        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            var employees = await _manager.GetAllAsync();
            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeCommand employeeBody)
        {
            var employee = _mapper.Map<EmployeeDTO>(employeeBody);
            await _manager.CreateAsync(employee);
            return NoContent();    

        }
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromHybrid] UpdateEmployeeCommand employeeBody)
        {
            var employee = _mapper.Map<EmployeeDTO>(employeeBody);
            await _manager.UpdateAsync(employee);
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            await _manager.DeleteAsync(id);
            return NoContent();
        }
    }
}
