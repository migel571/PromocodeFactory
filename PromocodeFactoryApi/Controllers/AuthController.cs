﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromocodeFactory.Service.DTO.Identity;
using PromocodeFactory.Service.Interfaces;
using PromocodeFactory.Api.Commands;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace PromocodeFactory.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    //[Authorize(Policy="AdminOnly")]
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
        public async Task<IActionResult> RegisterAsync([FromBody] RegistrationUserCommand user)
        {
            if (user.Role != "Customer")
            {
                string userIdentity = User.Claims.First(x => x.Type == ClaimTypes.Role).Value;
                if (userIdentity != "Admin")
                {
                    return BadRequest(new UserRegistrationResponseDTO { Error = "У вас не хватает прав для регистрации пользователя", Message = "У вас не хватает прав для регистрации пользователя", IsSuccess = false });
                }
            }
            var result = await _manager.RegisterUserAsync(_mapper.Map<UserRegistrationDTO>(user));
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
