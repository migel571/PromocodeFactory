using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using PromocodeFactory.UI.AuthProviders;
using PromocodeFactory.UI.Interfaces.Auth;
using PromocodeFactory.UI.Models.Auth;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace PromocodeFactory.UI.Repositories.Auth
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly ILocalStorageService _localStorage;
        public AuthenticationService(HttpClient client, AuthenticationStateProvider authStateProvider, ILocalStorageService localStorage)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _authStateProvider = authStateProvider;
            _localStorage = localStorage;
        }

       

        public async Task<RegistrationUserResponse> RegisterUser(UserRegistration userRegistration)
        {
            var content = JsonSerializer.Serialize(userRegistration);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var registrationResult = await _client.PostAsync("auth/Register", bodyContent);
            var registrationContent = await registrationResult.Content.ReadAsStringAsync();
            if (!registrationResult.IsSuccessStatusCode)
            {
                var result = JsonSerializer.Deserialize<RegistrationUserResponse>(registrationContent, _options);
                return result;
            }
            return new RegistrationUserResponse { IsSuccess = true };
        }
        public async Task<LoginUserResponse> Login(UserAuthentication userAuthentication)
        {
            var content = JsonSerializer.Serialize(userAuthentication);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var authResult = await _client.PostAsync("auth/Login", bodyContent);
            var authContent = await authResult.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<LoginUserResponse>(authContent, _options);
            if (!authResult.IsSuccessStatusCode)
                return result;
            await _localStorage.SetItemAsync("authToken", result.Message);
            ((AuthStateProvider)_authStateProvider).NotifyUserAuthentication(result.Message);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Message);
            return new LoginUserResponse { IsSuccess = true };
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((AuthStateProvider)_authStateProvider).NotifyUserLogout();
            _client.DefaultRequestHeaders.Authorization = null;
        }
    }
}
