using Microsoft.AspNetCore.Components;
using PromocodeFactory.UI.Interfaces.Auth;
using PromocodeFactory.UI.Models.Auth;

namespace PromocodeFactory.UI.Pages
{
    public partial class Registration
    {
        private UserRegistration _userRegistration = new UserRegistration();
        [Inject]
        public IAuthenticationService AuthenticationService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public bool ShowRegistrationErrors { get; set; }
        public string Error { get; set; }
        public async Task Register()
        {
            ShowRegistrationErrors = false;
            if (_userRegistration.Role == null)
            {
                _userRegistration.Role = "Customer";
            }
            var result = await AuthenticationService.RegisterUser(_userRegistration);
            if (!result.IsSuccess)
            {
                Error = Error;
                ShowRegistrationErrors = true;
            }
            else
            {
                if (_userRegistration.Role == "Admin") NavigationManager.NavigateTo("/");
                else  NavigationManager.NavigateTo("/Create" + _userRegistration.Role); 
                
            }
        }
    }
}
