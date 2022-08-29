using AutoMapper;
using HybridModelBinding;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromocodeFactory.Service.DTO.PromocodeManagment;
using PromocodeFactory.Service.Interfaces;
using PromocodeFactory.Api.Commands;

namespace PromocodeFactory.Api.Controllers
{
    [Route("api/[controller]")]
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

        [HttpGet("GetAllPreference")]
        public async Task<IActionResult> GetAllPreferences()
        {
            var preferences = await _manager.GetAllAsync();
            return Ok(preferences);
        }
        [HttpGet("GetPreference")]
        public async Task<IActionResult> GetPreference(string name)
        {
            var preference = await _manager.GetAsync(name);
            return Ok(preference);
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
