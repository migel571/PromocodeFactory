using AutoMapper;
using HybridModelBinding;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PromocodeFactory.Infrastructure.Paging;
using PromocodeFactory.Service.DTO.Administration;
using PromocodeFactory.Service.Interfaces;
using PromocodeFactory.Api.Commands;
using Microsoft.AspNetCore.Authorization;

namespace PromocodeFactory.Api.Controllers
{
    [Route("api/employees")]
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
        [Authorize(Policy = "AdminOnly")]
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees([FromQuery] PagingParameters employeeParameters)
        {
            var employees = await _manager.GetAllAsync(employeeParameters);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(employees.MetaData));
            return Ok(employees);
        }
        [Authorize(Policy = "EmployeeOnly")]
        [HttpGet("{employeeId:Guid}")]
        public async Task<IActionResult> GetEmployee(Guid employeeId)
        {
            var employee = await _manager.GetAsync(employeeId);
            return Ok(employee);
        }
        [Authorize(Policy = "AdminOnly")]
        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeCommand employeeBody)
        {
            var employee = _mapper.Map<EmployeeDTO>(employeeBody);
            await _manager.CreateAsync(employee);
            return Ok(employee);    

        }
        [Authorize(Policy = "AdminOnly")]
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeCommand employeeBody)
        {
            var employee = _mapper.Map<EmployeeDTO>(employeeBody);
            await _manager.UpdateAsync(employee);
            return Ok(employee);
        }
        [Authorize(Policy = "AdminOnly")]
        [HttpDelete("{employeeId:Guid}")]
        public async Task<IActionResult> DeleteEmployee(Guid employeeId)
        {
            await _manager.DeleteAsync(employeeId);
            return Ok();
        }
    }
}
