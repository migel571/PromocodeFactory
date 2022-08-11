using PromocodeFactory.Service.DTO.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromocodeFactory.Service.Interfaces
{
    public interface IUserManager
    {
        public Task<UserRegistrationResponseDTO> RegisterUserAsync(UserRegistrationDTO user);
        public Task<UserLoginResponseDTO> LoginUserAsync(UserLoginDTO user);

    }
}
