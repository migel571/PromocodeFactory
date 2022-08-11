using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromocodeFactory.Service.DTO.Identity;
using PromocodeFactory.Service.Interfaces;
using PromocodeFactoryApi.Commands;

namespace PromocodeFactoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserManager _manager;
        private readonly IMapper _mapper;
        public AuthController(IUserManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody]RegistrationUserCommand user)
        {
           
                var result = await _manager.RegisterUserAsync(_mapper.Map<UserRegistrationDTO>( user));
                if (result.IsSuccess)
                    return Ok(result);
                return BadRequest(result);
            
            
        }
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginUserCommand user)
        {

            var result = await _manager.LoginUserAsync(_mapper.Map<UserLoginDTO>(user));
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);


        }
    }
}
