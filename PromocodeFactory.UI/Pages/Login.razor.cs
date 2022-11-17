using Microsoft.AspNetCore.Components;
using PromocodeFactory.UI.Interfaces.Auth;
using PromocodeFactory.UI.Models.Auth;

namespace PromocodeFactory.UI.Pages
{
    public partial class Login
    {
        private UserAuthentication _userAuthentication = new UserAuthentication();
        [Inject]
        public IAuthenticationService AuthenticationService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public bool ShowAuthError { get; set; }
        public string Error { get; set; }
        public async Task ExecuteLogin()
        {
            ShowAuthError = false;
            var result = await AuthenticationService.Login(_userAuthentication);
            if (!result.IsSuccess)
            {
                Error = result.Error;
                ShowAuthError = true;
            }
            else
            {
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
