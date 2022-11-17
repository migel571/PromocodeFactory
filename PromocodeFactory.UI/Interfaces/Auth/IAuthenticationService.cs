using PromocodeFactory.UI.Models.Auth;

namespace PromocodeFactory.UI.Interfaces.Auth
{
    public interface IAuthenticationService
    {
        Task<RegistrationUserResponse> RegisterUser(UserRegistration userRegistration);
        Task<LoginUserResponse> Login(UserAuthentication userAuthentication);
        Task Logout();
    }
}
