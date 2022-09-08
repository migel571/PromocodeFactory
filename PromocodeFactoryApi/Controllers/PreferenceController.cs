using AutoMapper;
using HybridModelBinding;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromocodeFactory.Service.DTO.PromocodeManagment;
using PromocodeFactory.Service.Interfaces;
using PromocodeFactory.Api.Commands;
using PromocodeFactory.Infrastructure.Paging;
using Newtonsoft.Json;

namespace PromocodeFactory.Api.Controllers
{
    [Route("api/preferences")]
    [ApiController]
    public class PreferenceController : ControllerBase
    {
        private readonly IPreferenceManager _manager;
        private readonly IMapper _mapper;

        public PreferenceController(IPreferenceManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;   
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPreferences([FromQuery] PagingParameters preferenceParametres)
        {
            var preferences = await _manager.GetAllAsync(preferenceParametres);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(preferences.MetaData));
            return Ok(preferences);
        }
        [HttpGet("{preferenceId:Guid}")]
        public async Task<IActionResult> GetPreference(Guid preferenceId)
        {
            var preference = await _manager.GetAsync(preferenceId);
            return Ok(preference);
        }
        [HttpGet("customer/{customerId:Guid}")]
        public async Task<IActionResult> GetAllPreferencesByCustomerId(Guid customerId)
        {
            var preferences = await _manager.GetPreferencesByCustomerIdAsync(customerId);
            return Ok(preferences);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePreference([FromBody] CreatePreferenceCommand preferenceBody)
        {
            var preference = _mapper.Map<PreferenceDTO>(preferenceBody);
            await _manager.CreateAsync(preference);
            return Ok(preference);
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePreference([FromHybrid] UpdatePreferenceCommand preferenceBody)
        {
            var preference = _mapper.Map<PreferenceDTO>(preferenceBody);
            await _manager.UpdateAsync(preference);
            return Ok(preference);
        }
        [HttpDelete]
        public async Task<IActionResult> DeletePreference(Guid preferenceId)
        {
            await _manager.DeleteAsync(preferenceId);
            return Ok();
        }
    }
}
