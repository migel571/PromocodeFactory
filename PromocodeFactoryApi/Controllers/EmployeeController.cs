using AutoMapper;
using HybridModelBinding;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PromocodeFactory.Infrastructure.Paging;
using PromocodeFactory.Service.DTO.Administration;
using PromocodeFactory.Service.Interfaces;
using PromocodeFactory.Api.Commands;

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
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees([FromQuery] PagingParameters employeeParameters)
        {
            var employees = await _manager.GetAllAsync(employeeParameters);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(employees.MetaData));
            return Ok(employees);
        }
        [HttpGet("{employeeId:Guid}")]
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
            return Ok(employee);    

        }
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromHybrid] UpdateEmployeeCommand employeeBody)
        {
            var employee = _mapper.Map<EmployeeDTO>(employeeBody);
            await _manager.UpdateAsync(employee);
            return Ok(employee);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(Guid employeeId)
        {
            await _manager.DeleteAsync(employeeId);
            return Ok();
        }
    }
}
