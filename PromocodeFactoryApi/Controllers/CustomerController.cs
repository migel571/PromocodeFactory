using AutoMapper;
using HybridModelBinding;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PromocodeFactory.Infrastructure.Pagging;
using PromocodeFactory.Service.DTO.PromocodeManagment;
using PromocodeFactory.Service.Interfaces;
using PromocodeFactoryApi.Commands;

namespace PromocodeFactoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerManager _manager;
        private readonly IMapper _mapper;
        public CustomerController(ICustomerManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        [HttpGet("GetAllCustomers")]
        public async Task<IActionResult> GetAllCustomers([FromQuery]PaggingParameters customerParameters)
        {
            var customers = await _manager.GetAllAsync(customerParameters);
            var metadata = new
            {
                customers.TotalCount,
                customers.PageSize,
                customers.CurrentPage,
                customers.TotalPages,
                customers.HasNext,
                customers.HasPrevious

            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(customers);
        }
        [HttpGet("GetCustomer")]
        public async Task<IActionResult> GetCustomer(Guid customerId)
        {
            var customer = await _manager.GetAsync(customerId);
            return Ok(customer);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand customerBody)
        {
            var customer =  _mapper.Map<CustomerDTO>(customerBody);
            await _manager.CreateAsync(customer,customerBody.PreferenceIds);
            return Ok(customer);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCustomer([FromHybrid] UpdateCustomerCommand customerBody)
        {
            var customer = _mapper.Map<CustomerDTO>(customerBody);
            await _manager.UpdateAsync(customer, customerBody.PreferenceIds);
            return Ok(customer);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(Guid CustomerId)
        {
            await _manager.DeleteAsync(CustomerId);
            return Ok();
        }
    }
}
