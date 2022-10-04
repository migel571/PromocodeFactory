using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PromocodeFactory.UI;
using PromocodeFactory.UI.AuthProviders;
using PromocodeFactory.UI.Interfaces;
using PromocodeFactory.UI.Interfaces.Auth;
using PromocodeFactory.UI.Repositories;
using PromocodeFactory.UI.Repositories.Auth;
using System.Security.Claims;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireClaim(ClaimTypes.Role, "Admin"));
    options.AddPolicy("EmployeeOnly", policy => policy.RequireClaim(ClaimTypes.Role,"Employee", "Admin"));
    options.AddPolicy("PartnerOnly", policy => policy.RequireClaim(ClaimTypes.Role, "Partner", "Admin"));
    options.AddPolicy("CustomerOnly", policy => policy.RequireClaim(ClaimTypes.Role, "Customer", "Admin"));

});


//builder.Services.AddHttpClient("api", c =>
//{
//    c.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiUrl"));
//});
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiUrl")) });
builder.Services.AddCors(policy =>
{
    policy.AddPolicy("CorsPolicy", opt => opt
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()
        .WithExposedHeaders("X-Pagination"));
}
    );
//builder.Services.AddScoped(
//    sp => sp.GetService<IHttpClientFactory>().CreateClient("api"));
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IPreferenceRepository, PreferenceRepository>();
builder.Services.AddScoped<IPartnerRepository, PartnerRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IPromocodeRepository, PromocodeRepository>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();


await builder.Build().RunAsync();
