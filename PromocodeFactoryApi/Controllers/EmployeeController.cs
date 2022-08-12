using AutoMapper;
using HybridModelBinding;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PromocodeFactory.Infrastructure.Pagging;
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
        public async Task<IActionResult> GetAllEmployees([FromQuery] PaggingParameters employeeParameters)
        {
            var employees = await _manager.GetAllAsync(employeeParameters);
            var metadata = new
            {
                employees.TotalCount,
                employees.PageSize,
                employees.CurrentPage,
                employees.TotalPages,
                employees.HasNext,
                employees.HasPrevious

            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(employees);
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployee(Guid employeeId)
        {
            var employee = await _manager.GetAsync(employeeId);
            return Ok(employee);
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
        public async Task<IActionResult> DeleteEmployee(Guid employeeId)
        {
            await _manager.DeleteAsync(employeeId);
            return NoContent();
        }
    }
}
