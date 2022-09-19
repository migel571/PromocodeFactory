using AutoMapper;
using HybridModelBinding;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PromocodeFactory.Infrastructure.Paging;
using PromocodeFactory.Service.DTO.PromocodeManagment;
using PromocodeFactory.Service.Interfaces;
using PromocodeFactory.Api.Commands;

namespace PromocodeFactory.Api.Controllers
{
    [Route("api/customers")]
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

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers([FromQuery]PagingParameters customerParameters)
        {
            var customers = await _manager.GetAllAsync(customerParameters);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(customers.MetaData));
            return Ok(customers);
        }
        [HttpGet("{customerId:Guid}")]
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
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerCommand customerBody)
        {
            var customer = _mapper.Map<CustomerDTO>(customerBody);
            await _manager.UpdateAsync(customer, customerBody.PreferenceIds);
            return Ok(customer);
        }
        [HttpDelete("{customerId:Guid}")]
        public async Task<IActionResult> DeleteCustomer(Guid CustomerId)
        {
            await _manager.DeleteAsync(CustomerId);
            return Ok();
        }
    }
}
