using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PromocodeFactory.Domain.Administaration;
using PromocodeFactory.Domain.PromocodeManagement;
using PromocodeFactory.Infrastructure.Interfaces;
using PromocodeFactory.Infrastructure.Interfaces.AdministrationRep;
using PromocodeFactory.Infrastructure.Interfaces.PromocodeManagment;
using PromocodeFactory.Service.DTO.Identity;
using PromocodeFactory.Service.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PromocodeFactory.Service.Manager
{
    public class UserManager : IUserManager
    {
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IEmployeeRepository _employeeRep;
        private readonly IPartnerRepository _partnerRep;
        private readonly ICustomerRepository _customerRep;

        public UserManager(IMapper mapper, ILoggerManager logger, UserManager<IdentityUser> userManager, IConfiguration configuration, IEmployeeRepository employeeRep, IPartnerRepository partnerRep, ICustomerRepository customerRep)
        {
            _mapper = mapper;
            _logger = logger;
            _userManager = userManager;
            _configuration = configuration;
            _employeeRep = employeeRep;
            _partnerRep = partnerRep;
            _customerRep = customerRep;

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
            var identityUser = new  IdentityUser()
            {
                Email = user.Email,
                UserName = user.UserName
                
            };
            
            var result = await _userManager.CreateAsync(identityUser, user.Password);
            if (result.Succeeded)
            {
                
              
               
                var claim = new[] {
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.NameIdentifier, identityUser.Id)
                };
                await _userManager.AddClaimsAsync(identityUser, claim);
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
                Error = "User did not create"
            };
        }
        public async Task<UserLoginResponseDTO> LoginUserAsync(UserLoginDTO user)
        {
            var identityUser = await _userManager.FindByEmailAsync(user.Email);
            var claims = await _userManager.GetClaimsAsync(identityUser);
            if (identityUser == null)
            {
                _logger.LogInfo("There is no user with that Email address");
                return new UserLoginResponseDTO()
                {
                    Message = "There is no user with that Email address",
                    IsSuccess = false,
                    Error = "There is no user with that Email address"
                };

            }

            var result = await _userManager.CheckPasswordAsync(identityUser,user.Password);

            if (!result)
            {
                _logger.LogInfo("Invalid password");
                return new UserLoginResponseDTO()
                {
                    Message = "Invalid password",
                    IsSuccess = false,
                    Error = "Invalid password"

                };
            }

            //var claimsTo = new[]
            //{
            //    new Claim("Email", user.Email),
            //    new Claim(ClaimTypes.NameIdentifier, identityUser.Id)
                
            //};
            
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
