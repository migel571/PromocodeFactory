using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PromocodeFactory.Infrastructure.Interfaces;
using PromocodeFactory.Service.DTO.Identity;
using PromocodeFactory.Service.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PromocodeFactory.Service.Manager
{
    public class UserManager : IUserManager
    {
        private readonly ILoggerManager _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        public UserManager(ILoggerManager logger, UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _logger = logger;
            _userManager = userManager;
            _configuration = configuration; 
        }
        public async Task<UserRegistrationResponseDTO> RegisterUserAsync(UserRegistrationDTO user)
        {
            if (user.Password != user.ConfirmPassword)
            {
                _logger.LogInfo("Confirm password doesn't match the password");
                return new UserRegistrationResponseDTO()
                {
                    Message = "Confirm password doesn't match the password",
                    IsSuccess = false

                };
            }
            var identityUser = new IdentityUser()
            {
                Email = user.Email,
                UserName = user.UserName

            };
            var result = await _userManager.CreateAsync(identityUser, user.Password);
            if (result.Succeeded)
            {
                _logger.LogInfo("User created successfully!");
                return new UserRegistrationResponseDTO()
                {
                    Message = "User created successfully!",
                    IsSuccess = true
                };
            }
            _logger.LogInfo("User did not create");
            return new UserRegistrationResponseDTO()
            {
                Message = "User did not create",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }
        public async Task<UserLoginResponseDTO> LoginUserAsync(UserLoginDTO user)
        {
            var identityUser = await _userManager.FindByEmailAsync(user.Email);
            if (identityUser == null)
            {
                _logger.LogInfo("There is no user with that Email address");
                return new UserLoginResponseDTO()
                {
                    Message = "There is no user with that Email address",
                    IsSuccess = false
                 };

            }

            var result = await _userManager.CheckPasswordAsync(identityUser,user.Password);

            if (!result)
            {
                _logger.LogInfo("Invalid password");
                return new UserLoginResponseDTO()
                {
                    Message = "Invalid password",
                    IsSuccess = false
                   
                };
            }

            var claims = new[]
            {
                new Claim("Email", user.Email),
                new Claim(ClaimTypes.NameIdentifier, identityUser.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));
            string tokenAsAsync = new JwtSecurityTokenHandler().WriteToken(token);

            return new UserLoginResponseDTO()
            {
                Message = tokenAsAsync,
                IsSuccess = true
            };
        }
    }
}
