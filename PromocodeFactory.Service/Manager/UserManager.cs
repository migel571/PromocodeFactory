using Microsoft.AspNetCore.Identity;
using PromocodeFactory.Infrastructure.Interfaces;
using PromocodeFactory.Service.DTO.Identity;
using PromocodeFactory.Service.Interfaces;

namespace PromocodeFactory.Service.Manager
{
    public class UserManager : IUserManager
    {
        private readonly ILoggerManager _logger;
        private readonly UserManager<IdentityUser> _userManager;
        public UserManager(ILoggerManager logger, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }
        public async Task<UserRegistrationResponseDTO> RegisterUserAsync(UserRegistrationDTO user)
        {
            if (user.Password != user.ConfirmPassword)
            {
                _logger.LogInfo("Confirm password doesn't match the password");
                return  new UserRegistrationResponseDTO()
                {
                    Message ="Confirm password doesn't match the password",
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
    }
}
