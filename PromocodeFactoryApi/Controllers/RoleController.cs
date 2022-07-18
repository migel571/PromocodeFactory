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
    public class RoleController : ControllerBase
    {
        private readonly IRoleManager _manager;
        private readonly IMapper _mapper;

        public RoleController(IRoleManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _manager.GetAllAsync();
            return Ok(roles);
        }
        [HttpGet]
        public async Task<IActionResult> GetRole(string roleName)
        {
            var role = await _manager.GetAsync(roleName);
            return Ok(role);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleCommand roleBody)
        {

            var role = _mapper.Map<RoleDTO>(roleBody);
            await _manager.CreateAsync(role);
            return NoContent();

        }

        [HttpPut]
        public async Task<IActionResult> UpdateRole([FromHybrid] UpdateRoleCommand roleBody )
        {
            var role = _mapper.Map<RoleDTO>(roleBody);
            await _manager.UpdateAsync(role);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRole(Guid id)
        {
            await _manager.DeleteAsync(id);
            return NoContent();
        }
    }
}
